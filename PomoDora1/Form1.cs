using System.Windows.Forms;

namespace PomoDora
{
    public partial class MainForm : Form
    {
        private int _ticks, h,m,s;
        private bool firstStarted, isOver, isStudying;

        public MainForm()
        {
            InitializeComponent();
            //Unintentional slow when unpausing
            //implement random greetings, everyday tips
            //implement tutorial
            //add contacts to github, change anchoring
            label1.Text = "Greetings";
            label1.Font = new System.Drawing.Font("Segoe UI", 80F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            m = 25; // !main 
            s = 0;// !variables
            firstStarted = true;
            isOver = false;
            isStudying = true;
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //menuToolStripMenuItem.BackColor = Color.OrangeRed;
            //menuToolStripMenuItem.ForeColor = Color.Purple;            
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = $"{m}:{s:00}";
            this.Text = $"{m}:{s:00} - PomoDora"; // -> в полоске приложения
            this.label1.Font = new System.Drawing.Font("Segoe UI", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            if (isOver == true && isStudying == false)
            {
                m += 5;
                label1.Size = new System.Drawing.Size(784, 164);
                isOver = false;
                firstStarted = true;
            } else if (isOver == true && isStudying == true)
            {
                m += 25;
                label1.Size = new System.Drawing.Size(784, 164);
                isOver = false;
                firstStarted = true;
            }
            if (firstStarted == true) // Skip of unintentional second
            {
                m -= 1;
                s += 59;
                firstStarted = false;
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            
            label1.Text = $"{m}:{s:00}";
            this.Text = $"{m}:{s:00} - PomoDora"; // -> в полоске приложения
            if (s == 0)
            {
                if(m > 0)
                {
                    m -= 1;
                    s += 60;
                }
                else
                {
                    timer1.Stop();
                    isOver = true;
                    if (isStudying == true)
                    {
                        label1.Text = "Congrats, start a break ?";
                        label1.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                        this.label1.Size = new System.Drawing.Size(784, 80);
                        isStudying = false;
                        s += 1;
                    } 
                    else
                    {
                        label1.Text = "Time to study yet again =)";
                        label1.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                        this.label1.Size = new System.Drawing.Size(784, 80);
                        isStudying = true;
                        s += 1;
                    }
                }                    
            }
            s -= 1;

            /*
            if(_ticks == 10)
            {
                this.Text = "Done";  
                timer1.Stop();
            }
            */

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}