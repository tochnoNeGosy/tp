using System.ComponentModel;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C_BazovoeZadanie
{
    public partial class Form1 : Form
    {
        PatientsList patients;

        public Form1()
        {
            InitializeComponent();
            patients = new PatientsList();
            patients.add(new Patient(13, 2, "asd", "ghj"));
            patients.add(new Patient(15, 3, "zxc", "tyu"));
            patients.add(new Patient(16, 4, "qwe", "vbn"));
            listBox1.DataSource = patients.patients;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string fcs = textBoxfcs.Text.Trim();
            string sick = textBoxSick.Text.Trim();
            string sage = textBoxAge.Text.Trim();
            string sroom = textBoxRoom.Text.Trim();
            if (fcs == "" || sick == "" || sage == "" || sroom == "")
            {
                MessageBox.Show("Все поля обязательны к заполнению", "Внимание");
                return;
            }
            int age = -1;
            int room = -1;
            if (!int.TryParse(sage, out age) || !int.TryParse(sroom, out room))
            {
                MessageBox.Show("Возраст и номер палаты должн быть цеелым положительным числом", "Внимание");
                return;
            }
            if (age < 0 || room < 0)
            {
                MessageBox.Show("Возраст и номер палаты должн быть цеелым положительным числом", "Внимание");
                return;
            }
            Patient patient = new Patient(age, room, fcs, sick);
            patients.add(patient);
        }

        private void buttonGetListOlder_Click(object sender, EventArgs e)
        {
            string sage = textBoxOlderThan.Text.Trim();
            if (sage == "")
            {
                MessageBox.Show("Поле обязательны к заполнению", "Внимание");
                return;
            }
            int age = -1;
            if (!int.TryParse(sage, out age))
            {
                MessageBox.Show("Возраст цеелым числом", "Внимание");
                return;
            }
            List<String> olderthan = patients.olderThan(age);
            MessageBox.Show(string.Join("\n", olderthan), string.Format("пациенты старше {0} лет", age));
        }

        private void buttonMostPopularRoom_Click(object sender, EventArgs e)
        {
            MessageBox.Show(patients.mostPopularRoom().ToString(), "Самая популярная палата");
        }

        private void buttonLoadToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "xml files (*.xml)|*.xml";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFile.FileName;
                using FileStream stream = new FileStream(fileName, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Patient>));
                serializer.Serialize(stream, patients.patients);
            }
        }

        private void buttonLoadFrmFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "xml файлы (*.xml)|*.xml";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFile.FileName;
                using FileStream fileStream = new FileStream(fileName, FileMode.Open);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(BindingList<Patient>));
                BindingList<Patient> loadPatients = (BindingList<Patient>)xmlSerializer.Deserialize(fileStream);
                patients.patients.Clear();
                for (int i = 0; i < loadPatients.Count; ++i)
                {
                    patients.add(loadPatients[i]);
                }
            }
        }
    }
}