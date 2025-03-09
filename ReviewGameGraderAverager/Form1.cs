using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;



namespace ReviewGameGraderAverager
{
    public partial class DigitalReviewGameGradeAverager : Form
    {



        public DigitalReviewGameGradeAverager()
        {
            InitializeComponent();
            DragAndDropFilesBox.DragEnter += DragAndDropFilesBox_DragEnter;
            DragAndDropFilesBox.DragDrop += DragAndDropFilesBox_DragDrop;
        }



        private void OutputFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void DragAndDropFilesBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void DragAndDropFilesBox_DragEnter(object sender, DragEventArgs e)
        {
            // Allow file drop
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Allow copy operation
            }
        }

        private void DragAndDropFilesBox_DragDrop(object sender, DragEventArgs e)
        {
            // Get the dropped files (as an array of strings)
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Display the file names in the ListView
            foreach (string file in files)
            {
                // Create a ListViewItem with the file name
                ListViewItem listItem = new ListViewItem(file);

                // Add the ListViewItem to the ListView control
                DragAndDropFilesBox.Items.Add(listItem);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CreateNewDataButton_Click(object sender, EventArgs e)
        {
            // Process the CSV files and display the data
            ProcessAndDisplayData();
        }


        private void DownloadData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveFileDialog.FileName = OutputFileName.Text;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                // Add the header row
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    sb.Append(column.HeaderText + ",");
                }
                sb.AppendLine();

                // Add the data rows
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        sb.Append(cell.Value + ",");
                    }
                    sb.AppendLine();
                }

                // Write to the file
                File.WriteAllText(saveFileDialog.FileName, sb.ToString());
            }
        }


        private List<ScoreData> ReadCsvFile(string filePath, List<string> playerColumnNames, List<string> correctColumnNames, List<string> incorrectColumnNames, int minQuestionsThreshold)
        {
            var scoreDataList = new List<ScoreData>();

            try
            {
                // Read all lines from the CSV file
                var lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                    return scoreDataList;

                // Assuming the first line is the header, and subsequent lines are the data
                var header = lines[0].Split(',');

                int playerColumnIndex = -1;
                int correctColumnIndex = -1;
                int incorrectColumnIndex = -1;

                // Find column indices
                for (int i = 0; i < header.Length; i++)
                {
                    var columnName = header[i].Trim().ToLower();

                    if (playerColumnNames.Any(name => name.Trim().ToLower() == columnName))
                    {
                        playerColumnIndex = i;
                    }
                    if (correctColumnNames.Any(name => name.Trim().ToLower() == columnName))
                    {
                        correctColumnIndex = i;
                    }
                    if (incorrectColumnNames.Any(name => name.Trim().ToLower() == columnName))
                    {
                        incorrectColumnIndex = i;
                    }
                }

                if (playerColumnIndex == -1 || correctColumnIndex == -1 || incorrectColumnIndex == -1)
                {
                    MessageBox.Show("Unable to find necessary columns in the CSV file.");
                    return scoreDataList;
                }

                // Process the remaining lines for score data
                foreach (var line in lines.Skip(1)) // Skip header row
                {
                    var columns = line.Split(',');

                    var playerName = columns[playerColumnIndex].Trim(); // Keep capitalization for display
                    int correct = int.TryParse(columns[correctColumnIndex].Trim(), out int c) ? c : 0;
                    int incorrect = int.TryParse(columns[incorrectColumnIndex].Trim(), out int i) ? i : 0;

                    int totalAnswered = correct + incorrect;

                    // Adjust incorrect answers if below threshold
                    if (totalAnswered < minQuestionsThreshold)
                    {
                        incorrect += (minQuestionsThreshold - totalAnswered);
                        totalAnswered = minQuestionsThreshold;
                    }

                    decimal accuracy = totalAnswered > 0 ? (correct / (decimal)totalAnswered) * 100 : 0;

                    scoreDataList.Add(new ScoreData { PlayerName = playerName, Score = accuracy });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file {filePath}: {ex.Message}");
            }

            return scoreDataList;
        }

        // New Method to Convert .xlsx to .csv
        private string ConvertXlsxToCsv(string xlsxFilePath)
        {
            string tempCsvFilePath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(xlsxFilePath) + ".csv");

            try
            {
                // Open the Excel file using ClosedXML
                using (var workbook = new XLWorkbook(xlsxFilePath))
                {
                    var worksheet = workbook.Worksheets.Worksheet(1); // Assuming the data is in the first worksheet
                    var rows = worksheet.RowsUsed(); // Get all used rows

                    // Write the rows to a CSV file
                    using (var writer = new StreamWriter(tempCsvFilePath))
                    {
                        foreach (var row in rows)
                        {
                            var cells = row.Cells().Select(cell => cell.Value.ToString());
                            string line = string.Join(",", cells);
                            writer.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting {xlsxFilePath} to CSV: {ex.Message}");
            }

            return tempCsvFilePath;
        }

        private void ProcessAndDisplayData()
        {
            // Clear the DataGridView to prevent duplicate data
            dataGridView1.Rows.Clear();

            var allScoreData = new List<ScoreData>();


            var playerColumnNames = new List<string> { "Player Name", "PlayerName", "Name" }; // Add other possibilities
            var correctColumnNames = new List<string> { "Corrects", "Questions Answered Correctly" }; // Add other possibilities
            var incorrectColumnNames = new List<string> { "Incorrects", "Questions Answered Incorrectly"}; // Add other possibilities
                                                                                 
            int minQuestionsThreshold = (int)numericUpDown1.Value;

            // Loop through each file in the ListView and read data
            foreach (ListViewItem item in DragAndDropFilesBox.Items)
            {
                string filePath = item.Text;
                if (Path.GetExtension(filePath).ToLower() == ".xlsx")
                {
                    // Convert .xlsx to .csv
                    string tempCsvFilePath = ConvertXlsxToCsv(filePath);

                    // Process the converted CSV file
                    var scoreDataList = ReadCsvFile(tempCsvFilePath, playerColumnNames, correctColumnNames, incorrectColumnNames, minQuestionsThreshold);

                    // Optionally delete the temporary CSV file after processing
                    File.Delete(tempCsvFilePath);

                    // Add data from the current file to the list
                    allScoreData.AddRange(scoreDataList);
                }
                else if (Path.GetExtension(filePath).ToLower() == ".csv")
                {
                    // Process the CSV file directly
                    var scoreDataList = ReadCsvFile(filePath, playerColumnNames, correctColumnNames, incorrectColumnNames, minQuestionsThreshold);

                    // Add data from the current file to the list
                    allScoreData.AddRange(scoreDataList);
                }
                else
                {
                    MessageBox.Show("Unsupported file format. Only .csv and .xlsx files are supported.");
                }
               
              
            }

            // Group by player name (case-insensitive and ignore white space)
            var groupedData = allScoreData
                .GroupBy(s => s.PlayerName.Trim().ToLower()) // Normalize player name (case-insensitive and trim white space)
                .Select(g => new
                {
                    PlayerName = g.Key,
                    Scores = g.Select(s => s.Score).ToList()
                })
                .Select(g => new
                {
                    PlayerName = g.PlayerName,
                    Average = AverageScores(g.Scores),
                    Lowest = g.Scores.Min(),
                    Highest = g.Scores.Max()
                })
                .ToList();

            // Create columns in DataGridView if not already created
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Player Name", "Player Name");
                dataGridView1.Columns.Add("Average", "Average");
                dataGridView1.Columns.Add("Lowest", "Lowest");
                dataGridView1.Columns.Add("Highest", "Highest");
            }

            // Display the data in DataGridView
            foreach (var playerData in groupedData)
            {
                dataGridView1.Rows.Add(playerData.PlayerName,
                                       $"{playerData.Average:F2}%",  // Display Average as formatted percentage
                                       $"{playerData.Lowest:F2}%",   // Display Lowest as formatted percentage
                                       $"{playerData.Highest:F2}%"); // Display Highest as formatted percentage
            }


        }



        private decimal AverageScores(IEnumerable<decimal> scores)
        {
            if (!scores.Any())
                return 0m; // If no valid scores, return 0

            return scores.Average();  // Calculate and return the average of the decimals
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (DragAndDropFilesBox.SelectedItems.Count > 0)
            {
                // Create a temporary list to store selected items
                var itemsToRemove = DragAndDropFilesBox.SelectedItems.Cast<ListViewItem>().ToList();

                // Now remove items safely outside the loop
                foreach (var item in itemsToRemove)
                {
                    DragAndDropFilesBox.Items.Remove(item);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DragAndDropFilesBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) // Check if Delete key was pressed
            {
                if (DragAndDropFilesBox.SelectedItems.Count > 0)
                {
                    // Create a separate list to store selected items
                    List<ListViewItem> itemsToRemove = new List<ListViewItem>();

                    foreach (ListViewItem item in DragAndDropFilesBox.SelectedItems)
                    {
                        itemsToRemove.Add(item); // Store selected items first
                    }

                    // Now remove them safely
                    foreach (var item in itemsToRemove)
                    {
                        DragAndDropFilesBox.Items.Remove(item);
                    }
                }
            }
        }
    }
    public class ScoreData
    {
        public string PlayerName { get; set; }
        public decimal Score { get; set; }
    }
}
