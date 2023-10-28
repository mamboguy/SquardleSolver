using ClassLibrary;

namespace SquardleSolver;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void comboBox_SquardleType_SelectedIndexChanged(object sender, EventArgs e)
    {
        var value = Enum.Parse<SquardleTypes>(comboBox_SquardleType.Text, true);

        GenerateGrid(value.GetGridSize());
    }

    private void GenerateGrid(int gridSize)
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                var textBox = new TextBox()
                {
                    AcceptsReturn = false,
                    AcceptsTab = false,
                    CharacterCasing = CharacterCasing.Upper,
                    Height = 100,
                    MaxLength = 1,
                    Multiline = false,
                    Text = "A" + gridSize,
                    TextAlign = HorizontalAlignment.Center,
                    Width = 100,
                };

                squardleGridPanel.Controls.Add(textBox);
            }
        }

        squardleGridPanel.Padding = new Padding(5);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {
        comboBox_SquardleType.Items.AddRange(new object[] { "Standard", "Express" });
    }
}