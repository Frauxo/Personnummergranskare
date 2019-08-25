//Skapad av Emil Hallin för en C# kurs år 2018. Created by Emil Hallin for a C# course in 2018.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personnrgranskare
{
    public class MinKlass
    {
        public bool testFail;

        public bool Algoritm21(long personnummer)
        {
            int summa = 0;
            long sifferHållare = personnummer;
            bool jämnt = true;

            for (long i = 1000000000; i > 0; i /= 10)
            {
                long tempSumma, tiotal, ental;

                tempSumma = ((sifferHållare - (personnummer % i)) / i);
                sifferHållare = personnummer % i;

                if (jämnt)
                {
                    tempSumma *= 2;
                    if (tempSumma >= 10)
                    {
                        tiotal = tempSumma / 10;
                        ental = tempSumma - 10;
                        summa += (int)tiotal + (int)ental;
                    }
                    else
                    {
                        summa += (int)tempSumma;
                    }
                    jämnt = false;
                }
                else
                {
                    summa += (int)tempSumma * 1;
                    jämnt = true;
                }
            }


            if (summa % 10 == 0)
            {
                testFail = false;
                return true;
            }
            else
            {
                testFail = true;
                return false;
            }
        }

        public bool Kön(int fyraSista)
        {
            int tempSiffra1 = 0;
            int tempSiffra2 = 0;
            int resultat = 0;

            tempSiffra1 = fyraSista - fyraSista % 1000;
            tempSiffra2 = fyraSista - tempSiffra1;
            tempSiffra1 = tempSiffra2 - fyraSista % 100;
            tempSiffra2 = tempSiffra2 - tempSiffra1;
            resultat = (tempSiffra2 - fyraSista % 10) / 10;

            if (resultat % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class personnummergranskare : System.Windows.Forms.Form
    {
        public System.Windows.Forms.Label förnamn;
        public System.Windows.Forms.Label efternamn;
        public System.Windows.Forms.Label personnummer;
        public System.Windows.Forms.Label välkommen;
        public System.Windows.Forms.Label instruktioner;
        public System.Windows.Forms.Label resultatPerson;
        public System.Windows.Forms.Label resultatKön;
        public System.Windows.Forms.TextBox förnamnText;
        public System.Windows.Forms.TextBox efternamnText;
        public System.Windows.Forms.TextBox personnummerText;
        public System.Windows.Forms.Button kalkylera;
        public System.Windows.Forms.Button avsluta;

        public personnummergranskare()
        {
            InitializeComponent();
        }

        private System.ComponentModel.Container components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        //Design layout
        private void InitializeComponent()
        {
            this.förnamn = new System.Windows.Forms.Label();
            this.efternamn = new System.Windows.Forms.Label();
            this.personnummer = new System.Windows.Forms.Label();
            this.välkommen = new System.Windows.Forms.Label();
            this.instruktioner = new System.Windows.Forms.Label();
            this.resultatPerson = new System.Windows.Forms.Label();
            this.resultatKön = new System.Windows.Forms.Label();
            this.förnamnText = new System.Windows.Forms.TextBox();
            this.efternamnText = new System.Windows.Forms.TextBox();
            this.personnummerText = new System.Windows.Forms.TextBox();
            this.kalkylera = new System.Windows.Forms.Button();
            this.avsluta = new System.Windows.Forms.Button();
            this.SuspendLayout();

            //Välkommen
            this.välkommen.Location = new System.Drawing.Point(200, 10);
            this.välkommen.Name = "välkommen";
            this.välkommen.Size = new System.Drawing.Size(350, 50);
            this.välkommen.TabIndex = 4;
            this.välkommen.Text = "Välkommen!";
            this.välkommen.Font = new Font("Georgia", 35, FontStyle.Bold);
            this.välkommen.ForeColor = Color.Black;
            //this.välkommen.BackColor = Color.Gray;

            //Förnamn
            this.förnamn.Location = new System.Drawing.Point(8, 100);
            this.förnamn.Name = "förnamn";
            this.förnamn.Size = new System.Drawing.Size(100, 20);
            this.förnamn.TabIndex = 4;
            this.förnamn.Text = "Förnamn:";
            this.förnamn.Font = new Font("Georgia", 12, FontStyle.Bold);
            this.förnamn.ForeColor = Color.Black;
            //this.förnamn.BackColor = Color.Gray;

            //Efternamn
            this.efternamn.Location = new System.Drawing.Point(8, 125);
            this.efternamn.Name = "efternamn";
            this.efternamn.Size = new System.Drawing.Size(130, 20);
            this.efternamn.TabIndex = 4;
            this.efternamn.Text = "Efternamn:";
            this.efternamn.Font = new Font("Georgia", 12, FontStyle.Bold);
            this.efternamn.ForeColor = Color.Black;
            //this.efternamn.BackColor = Color.Gray;

            //Personnummer
            this.personnummer.Location = new System.Drawing.Point(8, 150);
            this.personnummer.Name = "personnummer";
            this.personnummer.Size = new System.Drawing.Size(150, 20);
            this.personnummer.TabIndex = 4;
            this.personnummer.Text = "Personnummer:";
            this.personnummer.Font = new Font("Georgia", 12, FontStyle.Bold);
            this.personnummer.ForeColor = Color.Black;
            //this.personnummer.BackColor = Color.Gray;

            //Instruktioner
            this.instruktioner.Location = new System.Drawing.Point(450, 100);
            this.instruktioner.Name = "instruktioner";
            this.instruktioner.Size = new System.Drawing.Size(250, 400);
            this.instruktioner.TabIndex = 4;
            this.instruktioner.Text = "I detta program är din uppgift att skriva in personuppgifter. Programmet kollar sedan ifall det angivna personnummret är ett godkänt personnummer eller ej. Samt ifall det är en man eller kvinna.";
            this.instruktioner.Font = new Font("Georgia", 17, FontStyle.Bold);
            this.instruktioner.ForeColor = Color.Black;
            this.instruktioner.BackColor = Color.FromArgb(100, 201, 198, 197);

            //Resultat Person
            this.resultatPerson.Location = new System.Drawing.Point(10, 400);
            this.resultatPerson.Name = "resultatPerson";
            this.resultatPerson.Size = new System.Drawing.Size(400, 35);
            this.resultatPerson.TabIndex = 4;
            this.resultatPerson.Text = "";
            this.resultatPerson.Font = new Font("Georgia", 10, FontStyle.Bold);
            this.resultatPerson.ForeColor = Color.Black;
            this.resultatPerson.BackColor = Color.FromArgb(100, 201, 198, 197);

            //Resultat Kön
            this.resultatKön.Location = new System.Drawing.Point(10, 435);
            this.resultatKön.Name = "resultatKön";
            this.resultatKön.Size = new System.Drawing.Size(400, 35);
            this.resultatKön.TabIndex = 4;
            this.resultatKön.Text = "";
            this.resultatKön.Font = new Font("Georgia", 10, FontStyle.Bold);
            this.resultatKön.ForeColor = Color.Black;
            this.resultatKön.BackColor = Color.FromArgb(100, 201, 198, 197);

            //FörnamnText
            this.förnamnText.Location = new System.Drawing.Point(180, 100);
            this.förnamnText.Name = "förnamnText";
            this.förnamnText.Size = new System.Drawing.Size(130, 20);
            this.förnamnText.TabIndex = 2;
            this.förnamnText.Text = "";

            //EfternamnText
            this.efternamnText.Location = new System.Drawing.Point(180, 125);
            this.efternamnText.Name = "efternamnText";
            this.efternamnText.Size = new System.Drawing.Size(130, 20);
            this.efternamnText.TabIndex = 2;
            this.efternamnText.Text = "";

            //PersonnummerText
            this.personnummerText.Location = new System.Drawing.Point(180, 150);
            this.personnummerText.Name = "personnummerText";
            this.personnummerText.Size = new System.Drawing.Size(130, 20);
            this.personnummerText.TabIndex = 2;
            this.personnummerText.Text = "";

            //Kalkylera
            this.kalkylera.Location = new System.Drawing.Point(8, 190);
            this.kalkylera.Name = "kalkylera";
            this.kalkylera.Size = new System.Drawing.Size(125, 30);
            this.kalkylera.Text = "Granska";
            this.kalkylera.BackColor = Color.FromArgb(1, 201, 198, 197);
            this.kalkylera.Click += new System.EventHandler(granskaClick);

            //Avsluta
            this.avsluta.Location = new System.Drawing.Point(185, 190);
            this.avsluta.Name = "avsluta";
            this.avsluta.Size = new System.Drawing.Size(125, 30);
            this.avsluta.Text = "Avsluta";
            this.avsluta.BackColor = Color.FromArgb(1, 201, 198, 197);
            this.avsluta.Click += new System.EventHandler(avslutaProgrammet);

            this.AutoScaleDimensions = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.AddRange(
                new System.Windows.Forms.Control[]
                {
                    this.förnamn,
                    this.efternamn ,
                    this.personnummer,
                    this.välkommen,
                    this.instruktioner,
                    this.resultatPerson,
                    this.resultatKön,
                    this.förnamnText,
                    this.efternamnText,
                    this.personnummerText ,
                    this.kalkylera,
                    this.avsluta
                }
            );


            this.Name = "Personnummerkontroll";
            this.Text = "Personnummerkontroll";
            this.ResumeLayout(false);
            this.BackColor = Color.White;

        }

        #endregion

        //Initierare av programmet
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new personnummergranskare());
        }

        //Algoritmer och funktioner
        private void granskaClick(object sender, System.EventArgs e)
        {
            MinKlass funktioner = new MinKlass();
            long test, tempSistaFyra = 0, nyttPersonnummer = 0;
            bool godkänt;

            godkänt = Int64.TryParse(this.personnummerText.Text, out test);
            if (godkänt)
            {
                //Variabler för Algoritm21
                nyttPersonnummer = Int64.Parse(this.personnummerText.Text);

                if (funktioner.Algoritm21(nyttPersonnummer))
                {
                    this.resultatPerson.Text = "Personnummret för " + this.förnamnText.Text + " " + this.efternamnText.Text + " är Godkänt";
                }
                else
                {
                    this.resultatPerson.Text = "Personnummret för " + this.förnamnText.Text + " " + this.efternamnText.Text + " är icke godkänt";
                }

                //Variabler för Köncheck
                tempSistaFyra = Int64.Parse(this.personnummerText.Text);

                while (tempSistaFyra > 9999)
                {
                    if (tempSistaFyra > 1000000000)
                    {
                        tempSistaFyra -= 1000000000;
                    }
                    else if (tempSistaFyra > 100000000)
                    {
                        tempSistaFyra -= 100000000;
                    }
                    else if (tempSistaFyra > 10000000)
                    {
                        tempSistaFyra -= 10000000;
                    }
                    else if (tempSistaFyra > 1000000)
                    {
                        tempSistaFyra -= 1000000;
                    }
                    else if (tempSistaFyra > 100000)
                    {
                        tempSistaFyra -= 100000;
                    }
                    else
                    {
                        tempSistaFyra -= 10000;
                    }
                }

                int fyraSista = (int)tempSistaFyra;

                if (!funktioner.testFail)
                {
                    if (funktioner.Kön(fyraSista))
                    {
                        this.resultatKön.Text = "Personen är en kvinna";
                    }
                    else
                    {
                        this.resultatKön.Text = "Personen är en man";
                    }
                }
                else
                {
                    this.resultatKön.Text = "";
                }
            }
            else
            {
                this.resultatPerson.Text = "Personnumret får endast innehålla siffror, försök igen";
            }
        }

        private void avslutaProgrammet(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
