using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Bibop
{
    public partial class Form1 : Form
    {
        public static int RDBUTTON1;
        static string folderPath;
        public static int ClearCheck;
        public static string SearchFilter = "Name";
        public static int FilesNumber;
        public static string[] Names = new string[11];
        public static string[][] TagName = new string[12][];
        public static List<string> GridName = new List<string>();
        public static List<string> GridKind = new List<string>();
        public static List<string> GridVersion = new List<string>();
        public static List<string> GridDate = new List<string>();
        public static List<string> GridType = new List<string>();
        public static List<string> GridParticipant = new List<string>();
        public static List<string> GridProcess = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Название"; //текст в шапке
            column1.Width = 150; //ширина колонки
            column1.ReadOnly = true; //значение в этой колонке нельзя править
            column1.Name = "Name"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип колонки

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Soft Kind";
            column2.Name = "SoftKind";
            column2.CellTemplate = new DataGridViewTextBoxCell();
            column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Soft Version";
            column3.Name = "SoftVersion";
            column3.CellTemplate = new DataGridViewTextBoxCell();
            column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Date/Time";
            column4.Name = "DateTime";
            column4.CellTemplate = new DataGridViewTextBoxCell();
            column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Message Type";
            column5.Name = "MessageType";
            column5.CellTemplate = new DataGridViewTextBoxCell();
            column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "Participant ID";
            column6.Name = "ParticipantID";
            column6.CellTemplate = new DataGridViewTextBoxCell();
            column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "Process ID";
            column7.Name = "ProcessID";
            column7.CellTemplate = new DataGridViewTextBoxCell();
            column7.Width = 250;

            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);
            dataGridView1.Columns.Add(column5);
            dataGridView1.Columns.Add(column6);
            dataGridView1.Columns.Add(column7);

            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.Automatic;

            dataGridView1.AllowUserToAddRows = false; //запрещаем пользователю самому добавлять строк
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = true;

            TagName[0] = new string[] { "<app:SoftKind>", "</app:SoftKind>" };
            TagName[1] = new string[] { "<app:SoftVersion>", "</app:SoftVersion>" };
            TagName[2] = new string[] { "<roi:PreparationDateTime>", "</roi:PreparationDateTime>" };
            TagName[3] = new string[] { "<edh:MessageType>", "</edh:MessageType>" };
            TagName[4] = new string[] { "<edhead:MessageType>", "</edhead:MessageType>" };
            TagName[5] = new string[] { "<MessageType>", "</MessageType>" };
            TagName[6] = new string[] { "<edh:ParticipantID>", "</edh:ParticipantID>" };
            TagName[7] = new string[] { "<edhead:ParticipantID>", "</edhead:ParticipantID>" };
            TagName[8] = new string[] { "<ParticipantID>", "</ParticipantID>" };
            TagName[9] = new string[] { "<edh:ProccessID>", "</edh:ProccessID>" };
            TagName[10] = new string[] { "<edhead:ProccessID>", "</edhead:ProccessID>" };
            TagName[11] = new string[] { " ", " " };

            RDBUTTON1 = 2;

            Names[0] = "Soft Kind : ";
            Names[1] = "Soft Version : ";
            Names[2] = "Date Time : ";
            Names[3] = "Message Type : ";
            Names[4] = "Participant ID  : ";
            Names[5] = "Process ID : ";
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                Environment.Exit(0);
            }
            if (e.KeyCode == Keys.F1 && e.Alt && ClearCheck == 1)
            {
                this.Enabled = true;
                button4_Click(button4, e);
            }
        }
        public void button3_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                folderPath = FBD.SelectedPath;
                FilesNumber = new DirectoryInfo(folderPath).GetFiles("*.XML", SearchOption.AllDirectories).Length;
                Obrabotchik(folderPath, e);
            }
            else
            {
                return;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchFilter = comboBox1.SelectedItem.ToString();
            switch (SearchFilter)
            {
                case "Name":
                    SearchFilter = "Name";
                    break;
                case "Soft Kind":
                    SearchFilter = "SoftKind";
                    break;
                case "Soft Version":
                    SearchFilter = "SoftVersion";
                    break;
                case "Date/Time":
                    SearchFilter = "DateTime";
                    break;
                case "Message Type":
                    SearchFilter = "MessageType";
                    break;
                case "Participant ID":
                    SearchFilter = "ParticipantID";
                    break;
                case "Process ID":
                    SearchFilter = "ProcessID";
                    break;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (ClearCheck == 1)
            {
                if (radioButton1.Checked)
                {
                    RDBUTTON1 = 1;
                    dataGridView1.Rows.Clear();
                    progressBar1.Maximum = (int)FilesNumber;
                    Thread Radio1 = new Thread(RChecked1);
                    this.Enabled = false;
                    Radio1.Start();
                    void RChecked1()
                    {
                        progressBar1.Step = 1;
                        for (int i = 0; i < FilesNumber; i++, progressBar1.PerformStep())
                        {
                            if (GridName[i].Contains("gateway"))
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                            }
                            if (progressBar1.Value == (FilesNumber - 1))
                            {
                                this.Enabled = true;
                                progressBar1.Value = 0;
                                Thread Invoker = new Thread(invoker);
                                Invoker.Start();
                                void invoker()
                                {
                                    Invoke((MethodInvoker)delegate
                                    {

                                        dataGridView1.ScrollBars = ScrollBars.Both; // runs on UI thread
                                    });
                                }
                            }
                        }
                    }
                }
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (ClearCheck == 1)
            {
                this.Enabled = false;
                if (radioButton2.Checked)
                {
                    progressBar1.Value = 0;
                    progressBar1.Maximum = (int)FilesNumber;
                    RDBUTTON1 = 2;
                    dataGridView1.Rows.Clear();
                    Thread Radio2 = new Thread(RChecked2);
                    Radio2.Start();
                    void RChecked2()
                    {
                        for (int i = 0; i < FilesNumber; i++, progressBar1.PerformStep())
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                            dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                            dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                            dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                            dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                            dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                            dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];

                            if (i == FilesNumber - 1)
                            {
                                Thread Invoker = new Thread(invoker);
                                Invoker.Start();
                                void invoker()
                                {
                                    progressBar1.Value = 0;
                                    this.Enabled = true;
                                    Invoke((MethodInvoker)delegate
                                    {
                                        progressBar1.Value = 0;
                                        dataGridView1.ScrollBars = ScrollBars.Both;

                                    });
                                }
                            }

                        }
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty && ClearCheck == 1)
            {
                dataGridView1.Rows.Clear();
                if (RDBUTTON1 == 1)
                {
                    switch (SearchFilter)
                    {
                        case "Name":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridName[i] == textBox2.Text && GridName[i].Contains("gateway"))
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                                }
                            }
                            break;
                        case "SoftKind":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridKind[i] == textBox2.Text && GridName[i].Contains("gateway"))
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                                }
                            }
                            break;
                        case "SoftVersion":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridVersion[i] == textBox2.Text && GridName[i].Contains("gateway"))
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                                }
                            }
                            break;
                        case "DateTime":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridDate[i] == textBox2.Text && GridName[i].Contains("gateway"))
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                                }
                            }
                            break;
                        case "MessageType":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridType[i] == textBox2.Text && GridName[i].Contains("gateway"))
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                                }
                            }
                            break;
                        case "ParticipantID":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridParticipant[i] == textBox2.Text && GridName[i].Contains("gateway"))
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                                }
                            }
                            break;
                        case "ProcessID":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridProcess[i] == textBox2.Text && GridName[i].Contains("gateway"))
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                                }
                            }
                            break;
                    }
                }
                if (RDBUTTON1 == 2)
                {
                    switch (SearchFilter)
                    {
                        case "Name":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridName[i] == textBox2.Text)
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                                }
                            }
                            break;
                        case "SoftKind":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridKind[i] == textBox2.Text)
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                                }
                            }
                            break;
                        case "SoftVersion":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridVersion[i] == textBox2.Text)
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                                }
                            }
                            break;
                        case "DateTime":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridDate[i] == textBox2.Text)
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                                }
                            }
                            break;
                        case "MessageType":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridType[i] == textBox2.Text)
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                                }
                            }
                            break;
                        case "ParticipantID":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridParticipant[i] == textBox2.Text)
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];
                                }
                            }
                            break;
                        case "ProcessID":
                            for (int i = 0; i < FilesNumber; i++)
                            {
                                if (GridProcess[i] == textBox2.Text)
                                {

                                    dataGridView1.Rows.Add();
                                    dataGridView1["Name", dataGridView1.Rows.Count - 1].Value = GridName[i];
                                    dataGridView1["SoftKind", dataGridView1.Rows.Count - 1].Value = GridKind[i];
                                    dataGridView1["SoftVersion", dataGridView1.Rows.Count - 1].Value = GridVersion[i];
                                    dataGridView1["DateTime", dataGridView1.Rows.Count - 1].Value = GridDate[i];
                                    dataGridView1["MessageType", dataGridView1.Rows.Count - 1].Value = GridType[i];
                                    dataGridView1["ParticipantID", dataGridView1.Rows.Count - 1].Value = GridParticipant[i];
                                    dataGridView1["ProcessID", dataGridView1.Rows.Count - 1].Value = GridProcess[i];

                                }
                            }
                            break;
                    }
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (ClearCheck == 1)
            {
                progressBar1.Value = 0;
                textBox2.Text = "";
                comboBox1.SelectedItem = "Name";
                if (radioButton1.Checked == true)
                {
                    radioButton1_CheckedChanged(sender, e);
                }
                if (radioButton2.Checked == true)
                {
                    radioButton2_CheckedChanged(sender, e);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string Dir1 = folderPath;
            string copyfolderPath;
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = true;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                copyfolderPath = FBD.SelectedPath;
                //куда копируем
                string Dir2 = copyfolderPath;
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(Dir1);

                    List<int> rowList = dataGridView1.SelectedRows.Cast<DataGridViewRow>().Select(x => x.Index).ToList();
                    rowList.Sort();
                    progressBar1.Maximum = rowList.Count;
                    this.Enabled = false;
                    for (int i = 0; i < rowList.Count; i++, progressBar1.PerformStep())
                    {
                        string CopyTest = textBox2.Text;
                        try
                        {
                            int a = rowList[i];
                            if (dataGridView1.Rows[a].Cells["Name"].Value.ToString().Contains(CopyTest) == true ||
                                dataGridView1.Rows[a].Cells["SoftVersion"].Value.ToString().Contains(CopyTest) == true ||
                                dataGridView1.Rows[a].Cells["SoftKind"].Value.ToString().Contains(CopyTest) == true ||
                                dataGridView1.Rows[a].Cells["DateTime"].Value.ToString().Contains(CopyTest) == true ||
                                dataGridView1.Rows[a].Cells["MessageType"].Value.ToString().Contains(CopyTest) == true ||
                                dataGridView1.Rows[a].Cells["ParticipantID"].Value.ToString().Contains(CopyTest) == true ||
                                dataGridView1.Rows[a].Cells["ProcessID"].Value.ToString().Contains(CopyTest) == true)
                            {
                                string filename = dataGridView1.Rows[a].Cells["Name"].Value.ToString();
                                string filenameEnd = filename;
                                filename = Path.GetFileName(filename);
                                File.Copy(filenameEnd, Dir2 + "\\" + filename, true);
                            }
                            if (progressBar1.Value == rowList.Count - 1)
                            {
                                progressBar1.Value = 0;
                                this.Enabled = true;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("При копировании файлов произошла ошибка.");
                            break;
                        }
                    }
                    progressBar1.Value = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                return;
        }
        public void Enabler(object sender, EventArgs e)
        {
            if (progressBar1.Value == 7)
            {
                this.Enabled = true;
                progressBar1.Value = 0;
            }
        }
        public void Obrabotchik(object sender, EventArgs e)
        {
            progressBar1.Maximum = 7;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;

            ClearCheck = 1;
            this.Enabled = false;

            Thread Name = new Thread(obrabotkaName);
            Thread Kind = new Thread(obrabotkaKind);
            Thread Version = new Thread(obrabotkaVersion);
            Thread Date = new Thread(obrabotkaDate);
            Thread Type = new Thread(obrabotkaType);
            Thread Participant = new Thread(obrabotkaParticipant);
            Thread Process = new Thread(obrabotkaProcess);
            Process.Start();
            Participant.Start();
            Type.Start();
            Date.Start();
            Version.Start();
            Kind.Start();
            Name.Start();

            void obrabotkaName()
            {
                int i = 0;
                foreach (string file in Directory.EnumerateFiles(folderPath.ToString(), searchPattern: "*.XML", SearchOption.AllDirectories))
                {
                    i++;
                    string contents = File.ReadAllText(file);
                    GridName.Add(file);
                    if (i == FilesNumber)
                    {
                        progressBar1.Value++;
                    }
                    if (progressBar1.Value == 7)
                    {
                        Enabler(sender, e);
                    }
                }
            }
            void obrabotkaKind()
            {
                int i = 0;
                foreach (string file in Directory.EnumerateFiles(folderPath.ToString(), searchPattern: "*.XML", SearchOption.AllDirectories))
                {
                    i++;
                    string contents = File.ReadAllText(file);
                    int strTags = 0;

                    var str = contents;
                    var strAPP = TagName[strTags][0];

                    int indexOfStr = str.IndexOf(strAPP);

                    string strAPPend = TagName[strTags][1];
                    int indexOfSubstring = str.IndexOf(strAPPend);

                    if (indexOfSubstring < 0)
                    {
                        GridKind.Add("null");
                    }
                    else
                    {
                        str = str.Remove(indexOfSubstring);
                        str = str.Substring(indexOfStr + strAPPend.Length - 1);
                        GridKind.Add(str);
                    }
                    if (i == FilesNumber)
                    {
                        progressBar1.Value++;
                    }
                    if (progressBar1.Value == 7)
                    {
                        Enabler(sender, e);
                    }
                }
            }
            void obrabotkaVersion()
            {
                int i = 0;
                foreach (string file in Directory.EnumerateFiles(folderPath.ToString(), searchPattern: "*.XML", SearchOption.AllDirectories))
                {
                    i++;
                    string contents = File.ReadAllText(file);
                    int strTags = 1;

                    var str = contents;
                    var strAPP = TagName[strTags][0];

                    int indexOfStr = str.IndexOf(strAPP);

                    string strAPPend = TagName[strTags][1];
                    int indexOfSubstring = str.IndexOf(strAPPend);

                    if (indexOfSubstring < 0)
                    {
                        GridVersion.Add("null");
                    }
                    else
                    {
                        str = str.Remove(indexOfSubstring);
                        str = str.Substring(indexOfStr + strAPPend.Length - 1);
                        GridVersion.Add(str);
                    }
                    if (i == FilesNumber)
                    {
                        progressBar1.Value++;
                    }
                    if (progressBar1.Value == 7)
                    {
                        Enabler(sender, e);
                    }
                }
            }
            void obrabotkaDate()
            {
                int i = 0;
                foreach (string file in Directory.EnumerateFiles(folderPath.ToString(), searchPattern: "*.XML", SearchOption.AllDirectories))
                {
                    i++;
                    string contents = File.ReadAllText(file);
                    int strTags = 2;

                    var str = contents;
                    var strAPP = TagName[strTags][0];

                    int indexOfStr = str.IndexOf(strAPP);

                    string strAPPend = TagName[strTags][1];
                    int indexOfSubstring = str.IndexOf(strAPPend);

                    if (indexOfSubstring < 0)
                    {
                        GridDate.Add("null");
                    }
                    else
                    {
                        str = str.Remove(indexOfSubstring);
                        str = str.Substring(indexOfStr + strAPPend.Length - 1);
                        GridDate.Add(str);
                    }
                    if (i == FilesNumber)
                    {
                        progressBar1.Value++;
                    }
                    if (progressBar1.Value == 7)
                    {
                        Enabler(sender, e);
                    }
                }
            }
            void obrabotkaType()
            {
                int i = 0;
                foreach (string file in Directory.EnumerateFiles(folderPath.ToString(), searchPattern: "*.XML", SearchOption.AllDirectories))
                {
                    i++;
                    string contents = File.ReadAllText(file);
                    for (int strTags = 3; strTags < 6;)
                    {
                    m2:
                        var str = contents;
                        var strAPP = TagName[strTags][0];

                        int indexOfStr = str.IndexOf(strAPP);

                        string strAPPend = TagName[strTags][1];
                        int indexOfSubstring = str.IndexOf(strAPPend);

                        if (indexOfSubstring < 0 && strTags < 5)
                        {
                            strTags++;
                            goto m2;
                        }
                        if (indexOfSubstring < 0 && strTags == 5)
                        {
                            GridType.Add("null");
                            break;
                        }
                        else
                        {
                            str = str.Remove(indexOfSubstring);
                            str = str.Substring(indexOfStr + strAPPend.Length - 1);
                            GridType.Add(str);
                            break;
                        }
                    }
                    if (i == FilesNumber)
                    {
                        progressBar1.Value++;
                    }
                    if (progressBar1.Value == 7)
                    {
                        Enabler(sender, e);
                    }
                }
            }
            void obrabotkaParticipant()
            {
                int i = 0;
                foreach (string file in Directory.EnumerateFiles(folderPath.ToString(), searchPattern: "*.XML", SearchOption.AllDirectories))
                {
                    i++;
                    string contents = File.ReadAllText(file);
                    for (int strTags = 6; strTags < 9;)
                    {
                    m2:
                        var str = contents;
                        var strAPP = TagName[strTags][0];

                        int indexOfStr = str.IndexOf(strAPP);

                        string strAPPend = TagName[strTags][1];
                        int indexOfSubstring = str.IndexOf(strAPPend);

                        if (indexOfSubstring < 0 && strTags < 8)
                        {
                            strTags++;
                            goto m2;
                        }
                        if (indexOfSubstring < 0 && strTags == 8)
                        {
                            GridParticipant.Add("null");
                            break;
                        }
                        else
                        {
                            str = str.Remove(indexOfSubstring);
                            str = str.Substring(indexOfStr + strAPPend.Length - 1);
                            GridParticipant.Add(str);
                            break;
                        }
                    }
                    if (i == FilesNumber)
                    {
                        progressBar1.Value++;
                    }
                    if (progressBar1.Value == 7)
                    {
                        Enabler(sender, e);
                    }
                }
            }
            void obrabotkaProcess()
            {
                int i = 0;
                foreach (string file in Directory.EnumerateFiles(folderPath.ToString(), searchPattern: "*.XML", SearchOption.AllDirectories))
                {
                    i++;
                    string contents = File.ReadAllText(file);
                    for (int strTags = 9; strTags < 11;)
                    {
                    m2:
                        var str = contents;
                        var strAPP = TagName[strTags][0];

                        int indexOfStr = str.IndexOf(strAPP);

                        string strAPPend = TagName[strTags][1];
                        int indexOfSubstring = str.IndexOf(strAPPend);

                        if (indexOfSubstring < 0 && strTags < 10)
                        {
                            strTags++;
                            goto m2;
                        }
                        if (indexOfSubstring < 0 && strTags == 10)
                        {
                            GridProcess.Add("null");
                            break;
                        }
                        else
                        {
                            str = str.Remove(indexOfSubstring);
                            str = str.Substring(indexOfStr + strAPPend.Length - 1);
                            GridProcess.Add(str);
                            break;
                        }
                    }
                    if (i == FilesNumber)
                    {
                        progressBar1.Value++;
                    }
                    if (progressBar1.Value == 7)
                    {
                        Enabler(sender, e);
                    }
                }
            }
        }
    }
}