namespace Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;
            loadProductFromFile(file);
        }
        public void loadProductFromFile(string filepath)
        {
            string[] lines = System.IO.File.ReadAllLines(filepath);
            if (lines.Length > 0)
            {
                string firstline = lines[0];
                string[] head = firstline.Split(',');

                DataGridViewTextBoxColumn Name = new DataGridViewTextBoxColumn();
                Name.HeaderText = head[0];
                DataGridViewTextBoxColumn Price = new DataGridViewTextBoxColumn();
                Price.HeaderText = head[1];
                DataGridViewCheckBoxColumn Select = new DataGridViewCheckBoxColumn();
                Select.HeaderText = head[2];
                DataGridViewTextBoxColumn Amount = new DataGridViewTextBoxColumn();
                Amount.HeaderText = "Amount";
                dataGridView1.Columns.Add(Name);
                dataGridView1.Columns.Add(Price);
                dataGridView1.Columns.Add(Select);
                dataGridView1.Columns.Add(Amount);

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(',');
                    dataGridView1.Rows.Add(data[0], data[1], data[2]);
                }
            }

        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            double totalAll = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                bool checkedCell = Convert.ToBoolean(dataGridView1.Rows[i].Cells[2].Value);
                if (checkedCell == true)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    double totalS = Convert.ToDouble(row.Cells[1].Value);
                    double amount = Convert.ToDouble(row.Cells[3].Value);
                    totalS *= amount;
                    totalAll += totalS;
                    Box1.Text = totalAll.ToString();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double money = Convert.ToDouble(Box2.Text);
            double total = Convert.ToDouble(Box1.Text);
            double change = money - total;
            if (change > 0)
            {
                label4.Text = "Sucessful";
                Box3.Text = "Change = " + change.ToString();
            }
            else
            {
                label4.Text = "Sucessful";
                Box3.Text = "Lack of change = " + change.ToString();
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
    
}
