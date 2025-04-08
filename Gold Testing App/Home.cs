using System.Data;
using System.Drawing.Printing;
using System.Text;
using System.IO;
using Timer = System.Windows.Forms.Timer;
namespace Gold_Testing_App
{
    public partial class Home : Form
    {
        private int serialNo1;// to get first record and update the labelcount according the records 
        private List<string> records = new List<string>();
        private List<string> recordOriginal = new List<string>();
        private int currentIndex = -1;
        public int xc = 0;
        private string recordToPrint = ""; // Holds the specific record to print                                           
        private string fileReport = "C:/Users/rowdy/source/repos/Gold Testing App/Gold Testing App/bin/Debug/net9.0-windows/report.txt";
        //this is the Party master file path to save party details
        private string filePath = "C:/Users/rowdy/source/repos/Gold Testing App/Gold Testing App/bin/Debug/net9.0-windows/partymaster.txt";
        //private string fileItem = "C:/Users/rowdy/source/repos/Gold Testing App/Gold Testing App/bin/Debug/net9.0-windows/item.txt";
        List<string> list1 = []; // Change List<int> to List<string>
        private List<string> allNames = []; // Store all names from file
        public Home()
        {
            InitializeComponent();
        }


        //PARTY MASTER

        private void Home_Load(object sender, EventArgs e)
        {
            //Folder path to store report :- C:\Users\rowdy\source\repos\Gold Testing App\Gold Testing App\report\
            //MessageBox.Show($"Welcome bro this is working!!: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LoadDataToGridView();
            datePickerTouchMaster.Value = DateTime.Today;//set current date to the datetimepicker 
            LoadRecords();
            datePickerTouchMaster.Value = DateTime.Today;//set current date to the datetimepicker 
            LoadToReport();
            dateTimePicker1.Value = DateTime.Today;//set current date to the datetimepicker
            dateTimePicker2.Value = DateTime.Today;//set current date to the datetimepicker


        }
        private void LoadDataToGridView()
        {
            int x = File.ReadAllLines(filePath).Length;
            label11.Text = "" + x;
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                MessageBox.Show("The data file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Read all lines from the file
                var lines = File.ReadAllLines(filePath);
                // Create a DataTable to hold the data
                DataTable table = new DataTable();
                table.Columns.Add("Serial No", typeof(int));
                table.Columns.Add("PartyName");
                table.Columns.Add("ActualName");
                table.Columns.Add("ContactNo");
                table.Columns.Add("Address");
                // Populate the DataTable with data from the file
                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    if (data.Length == 5) // Ensure there are exactly 5 values (including serial number)
                    {
                        table.Rows.Add(int.Parse(data[0]), data[1], data[2], data[3], data[4]);
                    }
                }
                // Bind the DataTable to the DataGridView
                dataGridView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked cell is not in the header row
            if (e.RowIndex >= 0)
            {
                // Get the currently selected row
                DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                // Retrieve the data from the cells of the selected row and populate the text fields
                companynametxt.Text = selectedRow.Cells["PartyName"].Value?.ToString() ?? string.Empty;
                actualnametxt.Text = selectedRow.Cells["ActualName"].Value?.ToString() ?? string.Empty;
                contactnotxt.Text = selectedRow.Cells["ContactNo"].Value?.ToString() ?? string.Empty;
                addresstxt.Text = selectedRow.Cells["Address"].Value?.ToString() ?? string.Empty;
            }
        }
        private void savepict_Click(object sender, EventArgs e)
        {
            // Retrieve values from text boxes
            string partynm = companynametxt.Text.Trim();
            string actlnm = actualnametxt.Text.Trim();
            string addr = addresstxt.Text.Trim();
            string cont = contactnotxt.Text.Trim();
            // Validate inputs
            if (string.IsNullOrEmpty(partynm))
            {
                MessageBox.Show("Party Name is Compulsory only...", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                // Determine the new serial number
                int serialNo = 1;
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    if (lines.Length > 0)
                    {
                        // Get the serial number of the last record
                        var lastLine = lines[^1];
                        var lastSerial = lastLine.Split(',')[0];
                        serialNo = int.Parse(lastSerial) + 1;
                    }
                }

                // Combine the values into a single line separated by commas
                string dataLine = $"{serialNo},{partynm},{actlnm},{cont},{addr}";

                // Append the line to the file
                File.AppendAllText(filePath, dataLine + Environment.NewLine);

                // Inform the user that the operation was successful
                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the text boxes
                companynametxt.Text = "";
                actualnametxt.Text = "";
                addresstxt.Text = "";
                contactnotxt.Text = "";

                // Reload the grid view
                LoadDataToGridView();
            }
            catch (Exception ex)
            {
                // Handle any errors that might occur during file operations
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void updatepict_Click(object sender, EventArgs e)
        {
            // Retrieve updated values from text boxes
            string partynm = companynametxt.Text.Trim();
            string actlnm = actualnametxt.Text.Trim();
            string addr = addresstxt.Text.Trim();
            string cont = contactnotxt.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(partynm))
            {
                MessageBox.Show("Company Name Field only required. Please fill details.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Clear the text boxes
                companynametxt.Text = "";
                actualnametxt.Text = "";
                addresstxt.Text = "";
                contactnotxt.Text = "";
                return;
            }

            try
            {
                // Read all lines from the file
                var lines = File.ReadAllLines(filePath);
                List<string> updatedLines = new List<string>();
                bool recordUpdated = false;
                // Loop through each line
                foreach (var line in lines)
                {
                    var data = line.Split(',');

                    // Match the record to update based on Serial No (or another unique field)
                    if (data[1] == partynm) // Match based on Party Name
                    {
                        // Update the record
                        updatedLines.Add($"{data[0]},{partynm},{actlnm},{cont},{addr}");
                        recordUpdated = true;
                    }
                    else
                    {
                        updatedLines.Add(line);
                    }
                }

                // Write updated lines back to the file
                File.WriteAllLines(filePath, updatedLines);

                // Inform the user about the result
                if (recordUpdated)
                {
                    MessageBox.Show("Data updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToGridView(); // Reload grid view
                }
                else
                {
                    MessageBox.Show("No matching record found to update.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void deletepict_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // Retrieve the Serial No of the selected row (assuming "Serial No" is the first column)
                string selectedSerialNo = selectedRow.Cells["Serial No"].Value?.ToString() ?? string.Empty;
                try
                {
                    // Read all lines from the file
                    var lines = File.ReadAllLines(filePath).ToList();

                    // Remove the selected record based on Serial No
                    var updatedLines = lines.Where(line => !line.StartsWith(selectedSerialNo + ",")).ToList();

                    // Re-index the Serial No for the remaining records
                    var reIndexedLines = updatedLines
                        .Select((line, index) => $"{index + 1}," + string.Join(",", line.Split(',').Skip(1)))
                        .ToList();

                    // Write the updated lines back to the file
                    File.WriteAllLines(filePath, reIndexedLines);

                    // Reload the updated data into the DataGridView
                    LoadDataToGridView();

                    // Inform the user that the operation was successful
                    MessageBox.Show("Record deleted successfully and sequence updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the text boxes
                    companynametxt.Text = "";
                    actualnametxt.Text = "";
                    addresstxt.Text = "";
                    contactnotxt.Text = "";

                }
                catch (Exception ex)
                {
                    // Handle any errors during the delete operation
                    MessageBox.Show($"Error deleting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Inform the user to select a row first
                MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //TOUCH MASTER


        //FROM HERE THE IMPLEMENTATION OF THE TOUCH MASTER TAB CONTROL IS STARTED
        //Here i have written the code for event handling for touch master control tab        

        private void pctPrint_Click(object sender, EventArgs e)
        {
            PrintMatchingRecord(LabelCount.Text);
        }
        // Function to find and print a single matching record
        private void PrintMatchingRecord(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                MessageBox.Show("Please enter a valid search key!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(fileReport))
            {
                MessageBox.Show("CSV file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Read all lines and find the matching record
            string[] records = File.ReadAllLines(fileReport);
            recordToPrint = "";

            foreach (string line in records)
            {
                string[] columns = line.Split(','); // Assuming CSV format

                if (columns.Length > 0 && columns[0].Trim().Equals(searchKey, StringComparison.OrdinalIgnoreCase))
                {
                    recordToPrint = line;
                    break;
                }
            }

            if (string.IsNullOrEmpty(recordToPrint))
            {
                MessageBox.Show("Record not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Set up PrintDocument
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);

            // Show PrintDialog to select printer
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDoc
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDoc.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Printing Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Print event handler for formatting the record
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Font printFont = new("Arial", 12);
            Font headerFont = new("Arial", 14, FontStyle.Bold);
            float yPos = 50;
            float leftMargin = e.MarginBounds.Left;
            float rightMargin = e.MarginBounds.Right - 200; // Adjust right margin for alignment

            e.Graphics.DrawString("Record Details:", headerFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;

            string[] fields = recordToPrint.Split(',');

            if (fields.Length < 8) // Ensure the record has enough fields
            {
                e.Graphics.DrawString("Invalid Record Format!", printFont, Brushes.Red, leftMargin, yPos);
                return;
            }

            // Left Side: First 3 values
            float leftColumnX = leftMargin;
            float rightColumnX = rightMargin; // Right side for remaining fields

            e.Graphics.DrawString($"Serial No. : {fields[0].Trim()}", printFont, Brushes.Black, leftColumnX, yPos);
            yPos += 25;
            e.Graphics.DrawString($"Party Weight : {fields[5].Trim()}", printFont, Brushes.Black, leftColumnX, yPos);
            yPos += 25;
            e.Graphics.DrawString($"Date : {fields[1].Trim()}", printFont, Brushes.Black, leftColumnX, yPos);
            yPos += 25;
            e.Graphics.DrawString($"Lab Weight : {fields[6].Trim()}", printFont, Brushes.Black, leftColumnX, yPos);

            // Reset yPos for the right side
            float rightYPos = 90; // Start below the header for alignment

            e.Graphics.DrawString($"M/S : {fields[2].Trim()}", printFont, Brushes.Black, rightColumnX, rightYPos);
            rightYPos += 25;
            e.Graphics.DrawString($"Item : {fields[3].Trim()}", printFont, Brushes.Black, rightColumnX, rightYPos);
            rightYPos += 25;
            e.Graphics.DrawString($"Lot No. : {fields[4].Trim()}", printFont, Brushes.Black, rightColumnX, rightYPos);
            rightYPos += 25;
            e.Graphics.DrawString($"Fitness Touch : {fields[7].Trim()}", printFont, Brushes.Black, rightColumnX, rightYPos);
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
            decimal balWT = 0;
            decimal pwt;
            if (!decimal.TryParse(partywttxtbx.Text, out pwt))
                pwt = 0;

            for (int i = 0; i < dataGridViewTouch.RowCount; i++)
            {
                decimal initialWT = 0, processedWT = 0, partyWT = 0;

                if (!decimal.TryParse(Convert.ToString(dataGridViewTouch.Rows[i].Cells[1].Value), out initialWT))
                    initialWT = 0;

                if (!decimal.TryParse(Convert.ToString(dataGridViewTouch.Rows[i].Cells[2].Value), out processedWT))
                    processedWT = 0;

                if (!decimal.TryParse(partywttxtbx.Text, out partyWT))
                    partyWT = 0;

                // Avoid division by zero
                decimal touchv = (initialWT != 0) ? (processedWT / initialWT) * 100 : 0;
                //decimal touchv = Math.Round(touchv, 4);
                // Ensure the column index exists before assigning a value
                if (dataGridViewTouch.ColumnCount > 4)
                    dataGridViewTouch.Rows[i].Cells[4].Value = Math.Round(touchv, 2);

                if (dataGridViewTouch.ColumnCount > 3)
                    dataGridViewTouch.Rows[i].Cells[3].Value = 100.0;

                // Balance weight calculation
                balWT = balWT + initialWT;
            }
            balwttxt.Text = (pwt - balWT).ToString("0.0000");
        }
        private void comboBoxFinal_Click(object sender, EventArgs e)
        {
            list1.Clear();

            // Retrieve DataTable from DataGridView
            DataTable? table = dataGridViewTouch.DataSource as DataTable;

            if (table != null && table.Rows.Count > 0) // Ensure DataTable exists and has rows
            {
                foreach (DataRow row in table.Rows)
                {
                    string? partyName = row["Touch"]?.ToString() ?? string.Empty;
                    list1.Add(partyName);
                }

                // Calculate the average of numeric values
                decimal sum = 0;
                int counts = 0;

                foreach (string str in list1)
                {
                    if (decimal.TryParse(str, out decimal value)) // Safe conversion
                    {
                        sum += value;
                        counts++;
                    }
                }

                if (counts > 0)
                {
                    list1.Add((sum / counts).ToString("F2") + "%");
                }
            }

            // Update ComboBox items
            comboBoxFinal.Items.Clear(); // Clear existing items
            comboBoxFinal.Items.AddRange(list1.ToArray());
        }
        private void SubButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure to Delete a Row?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // This method will execute after clicking OK
            if (result == DialogResult.OK)
            {
                DataTable? table = dataGridViewTouch.DataSource as DataTable;
                if (table != null && table.Rows.Count > 0) // Ensure DataTable exists and has rows
                {
                    table.Rows.RemoveAt(table.Rows.Count - 1); // Remove last row from DataTable
                }
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            DataTable? table = dataGridViewTouch.DataSource as DataTable;
            if (table != null)
            {
                table.Rows.Add(table.Rows.Count + 1, 0.00m, 0.00m, 100m, 0.00m); // Adjust columns accordingly
            }
            else
            {
                MessageBox.Show("DataGridView is not bound to a DataTable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pctPrev_Click(object sender, EventArgs e)
        {
            if (records.Count == 0)
            {
                MessageBox.Show("No records to navigate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentIndex > 0)
            {
                currentIndex--;
                PopulateDataToTouch(records[currentIndex]);
            }
            else
            {
                MessageBox.Show("Already at the first record.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void pctNext_Click(object sender, EventArgs e)
        {
            if (records.Count == 0)
            {
                MessageBox.Show("No records to navigate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentIndex < records.Count - 1)
            {
                currentIndex++;
                PopulateDataToTouch(records[currentIndex]);
                //MessageBox.Show(records[currentIndex]);
            }
            else
            {
                // MessageBox.Show("Already at the last record.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult result = MessageBox.Show("Are you sure to Go Next Without saving This Record ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                // This method will execute after clicking OK
                if (result == DialogResult.OK)
                {
                    int sy = currentIndex + 1;
                    EmptyPopulateDataToTouch(sy);
                    //MessageBox.Show(" Curr val: "+sy);
                }

            }
        }
        private void pctFirst_Click(object sender, EventArgs e)
        {
            if (records.Count == 0)
            {
                MessageBox.Show("No records available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentIndex != 0) // If not already at the first record
            {
                currentIndex = 0;
                PopulateDataToTouch(records[currentIndex]);
            }
            else
            {
                MessageBox.Show("Already at the first record.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void pctLast_Click(object sender, EventArgs e)
        {
            if (records.Count == 0)
            {
                MessageBox.Show("No records available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentIndex != records.Count - 1) // If not already at the last record
            {
                currentIndex = records.Count - 1;
                PopulateDataToTouch(records[currentIndex]);
            }
            else
            {
                MessageBox.Show("Already at the last record.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void pctRefresh_Click(object sender, EventArgs e)
        {
            LoadRecords();
            LoadToReport();
            datePickerTouchMaster.Value = DateTime.Today;//set current date to the datetimepicker 
            //MessageBox.Show("Page is refreshed..");
        }
        private void pctSave_Click(object sender, EventArgs e)
        {
            try
            {
                string date = datePickerTouchMaster.Value.ToString("yyyy-MM-dd");
                List<string> lines = new List<string>();
                int insertIndex = -1;
                int newSerialNumber = int.TryParse(LabelCount.Text, out int parsedSerial) ? parsedSerial : 1;

                if (File.Exists(fileReport) && new FileInfo(fileReport).Length > 0)
                {
                    lines = File.ReadAllLines(fileReport).ToList();

                    // Check if the record already exists
                    foreach (string line in lines.Skip(1)) // Skip header
                    {
                        string[] columns = line.Split(',');
                        if (columns.Length > 1 && columns[0] == newSerialNumber.ToString() && columns[1] == date)
                        {
                            MessageBox.Show("This record already exist Click next to save new record .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Find the last record with the same date
                    for (int i = 1; i < lines.Count; i++) // Skip header
                    {
                        string[] columns = lines[i].Split(',');
                        if (columns.Length > 1 && columns[1] == date)
                        {
                            insertIndex = i;
                            while (i < lines.Count && lines[i].Split(',')[1] == date)
                            {
                                insertIndex = i; // Keep moving to last matching date record
                                i++;
                            }
                            break;
                        }
                    }
                }

                if (insertIndex == -1) // No matching date found, insert at end
                {
                    insertIndex = lines.Count;
                }
                else
                {
                    insertIndex++; // Insert after the last matching date record
                }

                // Insert new record with proper serial number
                string comboBoxValue = comboBox.SelectedItem?.ToString() ?? "N/A";
                string itemText = ItemTextBox.Text;
                string labelText = textBoxLabel.Text;
                string partyWeight = partywttxtbx.Text;
                string ourWeight = ourwttxt.Text;
                string comboBoxval1 = comboBoxFinal.SelectedItem?.ToString() ?? "N/A";

                int rowCount = dataGridViewTouch.RowCount;
                List<string> initialValues = new List<string>();
                List<string> processValues = new List<string>();

                for (int i = 0; i < rowCount; i++)
                {
                    if (dataGridViewTouch.Rows[i].Cells[3].Value != null)
                        initialValues.Add(dataGridViewTouch.Rows[i].Cells[1].Value?.ToString() ?? "");
                    if (dataGridViewTouch.Rows[i].Cells[4].Value != null)
                        processValues.Add(dataGridViewTouch.Rows[i].Cells[2].Value?.ToString() ?? "");
                }

                string initialValuesCsv = string.Join(";", initialValues);
                string processValuesCsv = string.Join(";", processValues);

                string newLine = $"{newSerialNumber},{date},{comboBoxValue},{itemText},{labelText},{partyWeight},{ourWeight},{comboBoxval1},{initialValuesCsv},{processValuesCsv}";

                if (lines.Count == 0)
                {
                    lines.Add("Serial No,Date,ComboBox Value,Item,Label,Party Weight,Our Weight,Touch,Initial Weights,Processed Weights");
                }

                lines.Insert(insertIndex, newLine);

                File.WriteAllLines(fileReport, lines);

                MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //EmptyPopulateDataToTouch();
                LoadRecords();
                LoadToReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pctUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string date = datePickerTouchMaster.Value.ToString("yyyy-MM-dd");
                string comboBoxValue = comboBox.SelectedItem?.ToString() ?? comboBox.Text;
                string itemText = ItemTextBox.Text;
                string labelText = textBoxLabel.Text;
                string partyWeight = partywttxtbx.Text;
                string ourWeight = ourwttxt.Text;
                string comboBoxval1 = comboBoxFinal.SelectedItem?.ToString() ?? comboBoxFinal.Text;

                if (!int.TryParse(LabelCount.Text, out int serialNumber) || serialNumber <= 0)
                {
                    MessageBox.Show("Invalid Serial Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<string> initialValues = [];
                List<string> processValues = [];

                foreach (DataGridViewRow row in dataGridViewTouch.Rows)
                {
                    string initialValue = row.Cells[1]?.Value?.ToString()?.Trim() ?? "";
                    string processValue = row.Cells[2]?.Value?.ToString()?.Trim() ?? "";

                    if (!string.IsNullOrWhiteSpace(initialValue))
                        initialValues.Add(initialValue);
                    if (!string.IsNullOrWhiteSpace(processValue))
                        processValues.Add(processValue);
                }

                string initialValuesCsv = string.Join(";", initialValues);
                string processValuesCsv = string.Join(";", processValues);

                if (!File.Exists(fileReport))
                {
                    MessageBox.Show("Report file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<string> updatedLines = [];
                bool recordUpdated = false;

                using (StreamReader reader = new StreamReader(fileReport))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        var data = line.Split(',');

                        if (data.Length > 1 && data[1].Trim() == date && data[0].Trim() == LabelCount.Text)
                        {
                            updatedLines.Add($"{LabelCount.Text},{date},{comboBoxValue},{itemText},{labelText},{partyWeight},{ourWeight},{comboBoxval1},{initialValuesCsv},{processValuesCsv}");
                            recordUpdated = true;
                        }
                        else
                        {
                            updatedLines.Add(line);
                        }
                    }
                }

                File.WriteAllLines(fileReport, updatedLines);

                if (recordUpdated)
                {
                    MessageBox.Show("Data updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadToReport();
                }
                else
                {
                    MessageBox.Show("No matching record found to update.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (IOException exc)
            {
                MessageBox.Show($"File access error: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException exz)
            {
                MessageBox.Show($"Data format error: {exz.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pctDelete_Click(object sender, EventArgs e)
        {
            if (recordOriginal.Count == 0)
            {
                MessageBox.Show("No valid records available to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetDate = datePickerTouchMaster.Value.ToString("yyyy-MM-dd");
            string targetSerial = LabelCount.Text;
            int targetIndex = -1;

            for (int i = 0; i < recordOriginal.Count; i++)
            {
                string[] columns = recordOriginal[i].Split(',');
                if (columns.Length > 1 && columns[0] == targetSerial && columns[1] == targetDate)
                {
                    targetIndex = i;
                    break;
                }
            }

            if (targetIndex == -1)
            {
                MessageBox.Show("Record not found for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    recordOriginal.RemoveAt(targetIndex);
                    File.WriteAllLines(fileReport, recordOriginal);

                    if (recordOriginal.Count > 0)
                        PopulateDataToTouch(recordOriginal[Math.Min(targetIndex, recordOriginal.Count - 1)]);
                    else
                    {
                        LabelCount.Text = "";
                        datePickerTouchMaster.Value = DateTime.Now;
                        comboBox.Text = ItemTextBox.Text = textBoxLabel.Text = partywttxtbx.Text = ourwttxt.Text = comboBoxFinal.Text = "";
                        dataGridViewTouch.Rows.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                EmptyPopulateDataToTouch(targetIndex);
            }
            LoadRecords();
            LoadToReport();
        }
        private void LoadRecords()
        {
            //THIS IS THE CODE WRITTEN TO TRAVERSE BETWEEN THE CURRENT DATE RECORDS
            DateTime searchDate = datePickerTouchMaster.Value.Date;
            //HERE IS THE serialNo1 SHOWING FIRST CURRENT DATE SELECTED SERIAL NO. VALUE
            serialNo1 = File.ReadLines(fileReport).Skip(0).Select(line => line.Split(',')).Where(cols => DateTime.Parse(cols[1]).Date == searchDate).Select(cols => int.Parse(cols[0])).FirstOrDefault(0);

            try
            {
                if (File.Exists(fileReport))
                {
                    records = File.ReadAllLines(fileReport)
                                 .Where(line => !string.IsNullOrWhiteSpace(line)) // Remove empty lines
                                 .Select(line => line.Split(',')) // Split CSV line into columns
                                 .Where(cols => DateTime.TryParse(cols[1], out DateTime recordDate) && recordDate.Date == searchDate) // Filter by date
                                 .Select(cols => string.Join(",", cols)) // Convert back to CSV format if needed
                                 .ToList();
                    //READ THE DATA TO DELETE RECORDS FROM THE CSV FILE
                    recordOriginal = File.ReadAllLines(fileReport)
                                .Where(line => !string.IsNullOrWhiteSpace(line)) // Remove empty lines
                                .Select(line => line.Split(',')) // Split CSV line into columns                                
                                .Select(cols => string.Join(",", cols)) // Convert back to CSV format if needed
                                .ToList();
                    if (records.Count > 0)
                    {
                        currentIndex = records.Count - 1; // Start at the last matching record
                        PopulateDataToTouch(records[currentIndex]); // Populate data
                    }
                    else
                    {
                        MessageBox.Show("No records found for the selected date.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EmptyPopulateDataToTouch(0);
                        records.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("CSV file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateDataToTouch(string record)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(record))
                {
                    MessageBox.Show("Invalid record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var data = record.Split(',');
                if (data.Length < 10)
                {
                    MessageBox.Show("Invalid record format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //LabelCount.Text = data[0];
                //HERE IS THE serialNo1 SHOWING FIRST CURRENT DATE SELECTED SERIAL NO. VALUE
                int sn = Convert.ToInt32(data[0]); // Convert first column to int
                LabelCount.Text = (-1 * (serialNo1 - sn - 1)).ToString();
                datePickerTouchMaster.Value = DateTime.TryParse(data[1], out DateTime date) ? date : DateTime.Now;
                comboBox.Text = data[2];
                ItemTextBox.Text = data[3];
                textBoxLabel.Text = data[4];
                partywttxtbx.Text = data[5];
                ourwttxt.Text = data[6];
                comboBoxFinal.Text = data[7];

                // Extract weight values
                var initialValues = data[8].Split(';');
                var processValues = data[9].Split(';');

                // Create DataTable
                DataTable dt = new DataTable();
                dt.Columns.Add("Serial No", typeof(int));
                dt.Columns.Add("InitialWT", typeof(decimal));
                dt.Columns.Add("ProcessedWT", typeof(decimal));
                dt.Columns.Add("Percentage", typeof(string));
                dt.Columns.Add("Touch", typeof(string));

                // Populate DataTable
                for (int i = 0; i < Math.Max(initialValues.Length, processValues.Length); i++)
                {
                    string serialNo = (i + 1).ToString();
                    string initialWt = i < initialValues.Length ? initialValues[i] : "";
                    string processedWt = i < processValues.Length ? processValues[i] : "";
                    string percentage = "100"; // Default
                    string touch = "";

                    if (decimal.TryParse(initialWt, out decimal initial) && decimal.TryParse(processedWt, out decimal processed) && initial > 0)
                    {
                        percentage = "100";
                        touch = ((processed / initial) * 100).ToString("F2") + "%";
                    }

                    dt.Rows.Add(serialNo, initialWt, processedWt, percentage, touch);
                }

                // Bind DataTable to DataGridView
                dataGridViewTouch.DataSource = dt;

                // Set ReadOnly properties
                foreach (DataGridViewColumn col in dataGridViewTouch.Columns)
                {
                    if (col.Name == "Serial No" || col.Name == "Percentage" || col.Name == "Touch")
                    {
                        col.ReadOnly = true;
                    }
                }

                // Refresh Grid
                dataGridViewTouch.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EmptyPopulateDataToTouch(int s)
        {
            //EmptyPopulateDataToTouch();When no previous record found load this
            try
            {
                // Assign values to UI elements
                //int s = 0;                
                LabelCount.Text = (s + 1).ToString();//Increment count val by 2 to get next record this value
                //datePickerTouchMaster.Value = DateTime.Today;
                comboBox.Text = "";
                ItemTextBox.Text = "";
                textBoxLabel.Text = "";
                partywttxtbx.Text = "";
                ourwttxt.Text = "";
                comboBoxFinal.Text = "";
                balwttxt.Text = "";
                // Extract weight values
                //var initialValues = 0.00;
                //var processValues = 0.00;

                // Create DataTable
                DataTable dt = new DataTable();
                dt.Columns.Add("Serial No", typeof(int));
                dt.Columns.Add("InitialWT", typeof(decimal));
                dt.Columns.Add("ProcessedWT", typeof(decimal));
                dt.Columns.Add("Percentage", typeof(string));
                dt.Columns.Add("Touch", typeof(string));

                // Populate DataTable
                //for (int i = 0; i < 1; i++)
                //{
                string serialNo = "1";
                string initialWt = "0.00";
                string processedWt = "0.00";
                string percentage = "100"; // Default
                string touch = "";

                //if (decimal.TryParse(initialWt, out decimal initial) && decimal.TryParse(processedWt, out decimal processed) && initial > 0)
                //{
                //    percentage = ((processed / initial) * 100).ToString("F2") + "%";
                //    touch = ((processed / initial) * 100).ToString("F2") + "%";
                //}

                dt.Rows.Add(serialNo, initialWt, processedWt, percentage, touch);


                // Bind DataTable to DataGridView
                dataGridViewTouch.DataSource = dt;

                // Set ReadOnly properties
                foreach (DataGridViewColumn col in dataGridViewTouch.Columns)
                {
                    if (col.Name == "Serial No" || col.Name == "Percentage" || col.Name == "Touch")
                    {
                        col.ReadOnly = true;
                    }
                }

                // Refresh Grid
                dataGridViewTouch.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pctExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadToReport()
        {
            try
            {
                if (!File.Exists(fileReport))
                {
                    MessageBox.Show("CSV file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    //Create the new file to store records in the current location
                    //File.Create(report.txt);
                }
                var lines = File.ReadAllLines(fileReport).Reverse().ToList(); // Read all lines and reverse order
                DataTable dtr = new();
                //dtr.Columns.Add("Sample No. ", typeof(string));
                dtr.Columns.Add("Date", typeof(string));
                dtr.Columns.Add("Party Name", typeof(string));
                dtr.Columns.Add("Item Type", typeof(string));
                dtr.Columns.Add("Lot No", typeof(string));
                dtr.Columns.Add("Party Weight", typeof(string));
                dtr.Columns.Add("Lab Weight", typeof(string));
                dtr.Columns.Add("Final Touch", typeof(string));
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var data = line.Split(',');
                    if (data.Length < 10) continue;
                    dtr.Rows.Add(data[1], data[2], data[3], data[4], data[5], data[6], data[7]);
                }
                dataGridViewReport.DataSource = dtr;
                dataGridViewReport.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tabControlCal_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //CALCULATOR PROGRAM GET START FROM HERE

            if (e.TabPage == tabPage5) // Or use e.TabPageIndex == 1
            {
                //e.Cancel = true;
                Calculator cal = new Calculator();
                cal.Show();
            }
        }
        private void comboBox_MouseLeave(object sender, EventArgs e)
        {
            string searchText = comboBox.Text.Trim();
            try
            {
                if (!File.Exists(filePath)) // Check if file exists
                {
                    MessageBox.Show("Data file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);
                allNames.Clear(); // Clear list before adding new values

                foreach (string line in lines)
                {
                    string[] data1 = line.Split(','); // Assuming CSV format
                    if (data1.Length >= 2) // Ensure at least one name field exists
                    {
                        allNames.Add(data1[1].Trim()); // Trim spaces before storing names
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // If user entered a new name (not found in allNames)
            if (!string.IsNullOrEmpty(searchText) && !allNames.Contains(searchText, StringComparer.OrdinalIgnoreCase))
            {
                DialogResult result = MessageBox.Show(
                    $"'{searchText}' is not in the list. Do you want to add it?",
                    "Add New Name", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Determine the new serial number safely
                        int serialNo = 1;
                        if (File.Exists(filePath))
                        {
                            var lines = File.ReadAllLines(filePath);
                            if (lines.Length > 0)
                            {
                                var lastLine = lines[^1]; // Get last line
                                var lastSerialParts = lastLine.Split(',');

                                if (int.TryParse(lastSerialParts[0], out int lastSerial))
                                {
                                    serialNo = lastSerial + 1;
                                }
                            }
                        }

                        // Format the new entry properly
                        string dataLine = $"{serialNo},{searchText},{""},{""},{""}";

                        // Append the line to the file
                        File.AppendAllText(filePath, dataLine + Environment.NewLine);

                        // Add new name to in-memory list
                        allNames.Add(searchText);
                        LoadRecords();
                        LoadToReport();
                        MessageBox.Show("New name successfully added to the list.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception expt)
                    {
                        MessageBox.Show($"Error saving data: {expt.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        private void comboBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (xc == 0)
                {
                    xc = 1;
                    try
                    {
                        if (!File.Exists(filePath))
                        {
                            MessageBox.Show("Data file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string[] lines = File.ReadAllLines(filePath);
                        allNames.Clear();

                        foreach (string line in lines)
                        {
                            string[] data1 = line.Split(',');
                            if (data1.Length >= 2)
                            {
                                allNames.Add(data1[1].Trim());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string searchText = comboBox.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                    return;

                var filteredNames = allNames
                    .Where(name => name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                // Preserve the current text
                int cursorPosition = comboBox.SelectionStart;

                if (filteredNames.Count > 0)
                {
                    comboBox.DroppedDown = true; // Keep dropdown open to show suggestions
                    comboBox.Items.Clear();
                    comboBox.Items.AddRange(filteredNames.ToArray());
                }
                else
                {
                    comboBox.DroppedDown = false;
                }

                comboBox.SelectionStart = cursorPosition;
                comboBox.SelectionLength = 0; // Ensure cursor stays in the right position
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void datePickerTouchMaster_ValueChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        //REPORT PAGE

        //FROM HERE START THE CODE FOR REPORT PAGE BUTTON IMPLEMENTATION

        //REQUIRED FOR PRINTING MULTIPLE RECORDS// Class-level variables

        private int currentRowIndex = 0;
        private List<string[]> recordsToPrint = new();
        private PrintDocument printDoc = new PrintDocument(); // Class-level PrintDocument
                                                              // 
        private void pictureBoxPrintMul_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value != dateTimePicker2.Value)
            {
                MessageBox.Show("Select Single day Record to Print ...");
                return;
            }




            if (dataGridViewReport.Rows.Count == 0)
            {
                MessageBox.Show("No records available to print!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Extract data from DataGridView into a list
            recordsToPrint.Clear();
            foreach (DataGridViewRow row in dataGridViewReport.Rows)
            {
                if (!row.IsNewRow) // Avoid empty last row
                {
                    string[] record = new string[dataGridViewReport.ColumnCount];
                    for (int i = 0; i < dataGridViewReport.ColumnCount; i++)
                    {
                        record[i] = row.Cells[i].Value?.ToString() ?? "";
                    }
                    recordsToPrint.Add(record);
                }
            }

            currentRowIndex = 0; // Reset index before printing

            // Attach PrintPage event handler only once
            printDoc.PrintPage -= Printone; // Remove previous handler if exists
            printDoc.PrintPage += Printone; // Add new handler
            printDoc.DocumentName = "Printing Multiple Records";

            PrintDialog printDialog = new()
            {
                Document = printDoc
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDoc.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Printing Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Printone(object sender, PrintPageEventArgs e)
        {
            if (currentRowIndex >= recordsToPrint.Count)
            {
                e.HasMorePages = false; // Stop printing if all records are printed
                return;
            }

            Graphics g = e.Graphics;
            Font font = new Font("Arial", 12);
            Font headerFont = new Font("Arial", 14, FontStyle.Bold);
            Brush brush = Brushes.Black;
            int leftMargin = 50;
            int topMargin = 100;
            int xPos = leftMargin;
            int yPos = topMargin;

            // Print column headers (one-time per page)
            for (int i = 0; i < dataGridViewReport.ColumnCount; i++)
            {
                g.DrawString(dataGridViewReport.Columns[i].HeaderText, headerFont, brush, xPos, yPos);
                xPos += 200; // Adjust column width
            }

            yPos += 40; // Move below header

            // Print the current record (one record per page)
            xPos = leftMargin;
            for (int i = 0; i < recordsToPrint[currentRowIndex].Length; i++)
            {
                g.DrawString(recordsToPrint[currentRowIndex][i], font, brush, xPos, yPos);
                xPos += 200;
            }

            currentRowIndex++; // Move to the next record

            // If more records exist, print another page
            e.HasMorePages = (currentRowIndex < recordsToPrint.Count);

        }
        private void viewAllRecord_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure the correct file path is used                
                if (!File.Exists(fileReport))
                {
                    MessageBox.Show("Report file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string[] lines = File.ReadAllLines(fileReport);

                // Initialize DataTable
                DataTable dtr = new();
                dtr.Columns.Add("Label No.", typeof(string)); // Ensure Label No. is first
                dtr.Columns.Add("Date", typeof(string));
                dtr.Columns.Add("Party Name", typeof(string));
                dtr.Columns.Add("Item Type", typeof(string));
                dtr.Columns.Add("Lot No", typeof(string));
                dtr.Columns.Add("Party Weight", typeof(string));
                dtr.Columns.Add("Lab Weight", typeof(string));
                dtr.Columns.Add("Final Touch", typeof(string));
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] data = line.Split(',');
                    // Ensure there are enough columns before accessing indices
                    if (data.Length < 8) continue;

                    // Add filtered row to DataTable
                    dtr.Rows.Add(data[0], data[1], data[2], data[3], data[4], data[5], data[6], data.Length > 7 ? data[7] : "");
                }
                // Bind DataTable to DataGridView
                dataGridViewReport.DataSource = dtr;
                dataGridViewReport.Refresh();
                // Force column order in DataGridView
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                dataGridViewReport.Columns["Label No."].DisplayIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ViewAll_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure the correct file path is used                
                if (!File.Exists(fileReport))
                {
                    MessageBox.Show("Report file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Get the selected date range from DateTimePickers
                DateTime startDate = dateTimePicker1.Value.Date;
                DateTime endDate = dateTimePicker2.Value.Date;

                // Get filter values from textboxes (handling empty values)
                int labelFromval = int.TryParse(LabelFrom.Text, out int result) ? result : 0;
                int labelUptoval = int.TryParse(LabelUpto.Text, out int resultf) ? resultf : 0;
                string labelParty = LabelParty.Text.Trim();
                string labelItem = LableItem.Text.Trim();   //                                                            
                string labelLotNo = LableLotNo.Text.Trim(); // 
                // Read all lines from the file
                string[] lines = File.ReadAllLines(fileReport);

                // Initialize DataTable
                DataTable dtr = new();
                dtr.Columns.Add("Label No.", typeof(string)); // Ensure Label No. is first
                dtr.Columns.Add("Date", typeof(string));
                dtr.Columns.Add("Party Name", typeof(string));
                dtr.Columns.Add("Item Type", typeof(string));
                dtr.Columns.Add("Lot No", typeof(string));
                dtr.Columns.Add("Party Weight", typeof(string));
                dtr.Columns.Add("Lab Weight", typeof(string));
                dtr.Columns.Add("Final Touch", typeof(string));

                int snf = 0;

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] data = line.Split(',');
                    // Ensure there are enough columns before accessing indices
                    if (data.Length < 8) continue;

                    // Parse Date column (data[1])
                    if (!DateTime.TryParseExact(data[1], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out DateTime recordDate))
                    {
                        continue;
                    }

                    // Parse Serial Number (data[0])
                    if (!int.TryParse(data[0], out int sn)) continue;//HERE IS THE SERIAL NO. VALUE ERROR

                    // Apply filters
                    if (recordDate < startDate || recordDate > endDate) continue;
                    //THIS IS THE CODE WRITTEN TO GET THE FIRST SERIAL NO. VALUE and parse between label
                    if (snf == 0)
                    {
                        snf = Convert.ToInt32(data[0]); // 14 Convert first column to int
                        //MessageBox.Show("Serial No. First Value : " + snf);
                    }
                    // Apply filters to Lable No.
                    //if(LabelFrom==0)
                    //MessageBox.Show(" " + labelFromval);       
                    if (labelFromval == 0 && labelUptoval == 0)
                    {
                        labelFromval = 1;
                        labelUptoval = 100;
                    }
                    if (sn < snf + labelFromval - 1 || sn > snf + labelUptoval - 1) continue;//THIS give those record in label between
                    //if (sn < labelFrom || sn > labelUpto) continue;
                    if (!string.IsNullOrEmpty(labelParty) && !data[2].Equals(labelParty, StringComparison.OrdinalIgnoreCase)) continue;
                    if (!string.IsNullOrEmpty(labelItem) && !data[3].Equals(labelItem, StringComparison.OrdinalIgnoreCase)) continue;
                    if (!string.IsNullOrEmpty(labelLotNo) && !data[4].Equals(labelLotNo, StringComparison.OrdinalIgnoreCase)) continue;

                    // Add filtered row to DataTable
                    dtr.Rows.Add(sn - snf + 1, data[1], data[2], data[3], data[4], data[5], data[6], data.Length > 7 ? data[7] : "");
                }
                // Bind DataTable to DataGridView
                dataGridViewReport.DataSource = dtr;
                dataGridViewReport.Refresh();
                // Force column order in DataGridView
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                dataGridViewReport.Columns["Label No."].DisplayIndex = 0;
                //dataGridViewReport.Columns["Date"].DisplayIndex = 1;
                //dataGridViewReport.Columns["Party Name"].DisplayIndex = 2;
                //dataGridViewReport.Columns["Item Type"].DisplayIndex = 3;
                //dataGridViewReport.Columns["Lot No"].DisplayIndex = 4;
                //dataGridViewReport.Columns["PartyWeight"].DisplayIndex = 5;
                //dataGridViewReport.Columns["Final Touch"].DisplayIndex = 6;

                // Now clear textboxes to reset filters for the next search
                LabelParty.Text = "";
                LableItem.Text = "";
                LableLotNo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}