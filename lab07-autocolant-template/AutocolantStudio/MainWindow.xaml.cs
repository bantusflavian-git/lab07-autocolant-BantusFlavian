using System.Windows;
using System.Windows.Controls;        // Panel
using System.Windows.Input;           // MouseEventArgs
using System.Windows.Media;           // Brushes, Colors
using System.Windows.Media.Effects;   // DropShadowEffect

namespace AutocolantStudio
{
    /// <summary>
    /// Laboratorul 7 — Autocolant Studio.
    /// Completează metodele marcate cu TODO, în ordinea sarcinilor din fișa de lucru.
    /// Rulează aplicația (F5) după fiecare sarcină și fă un commit.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Valorile fixe ale aplicației
        private const int LungimeMaximaText = 14;
        private const string TextInitial = "Salut, WPF!";

        public MainWindow()
        {
            InitializeComponent();
        }

        // ---------- Sarcina 3. Deplasarea (A31, A35) ----------
        private void SldX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded) return;   // la pornire fereastra nu este gata

            DeplasareAutocolant.X = e.NewValue;
            TxtX.Text = $"X: {e.NewValue:0}";
        }


        private void SldY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded) return;

            DeplasareAutocolant.Y = e.NewValue;
            TxtY.Text = $"Y: {e.NewValue:0}";
        }

        // ---------- Sarcina 4. Rotirea și mărimea (A31) ----------
        private void SldUnghi_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            if (!IsLoaded) return;

            RotireAutocolant.Angle = e.NewValue;
            TxtUnghi.Text = $"Unghi: {e.NewValue:0}°";

        }

        private void SldScala_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Sarcina 8 (avansat): mută această logică într-o metodă AplicaScala()
            if (!IsLoaded) return;

            ScalareAutocolant.ScaleX = e.NewValue;
            ScalareAutocolant.ScaleY = e.NewValue;

            TxtScala.Text = $"Mărime: {e.NewValue * 100:0}%";


        }

        // ---------- Sarcina 8 (avansat). Oglindirea ----------
        private void ChkOglindit_Changed(object sender, RoutedEventArgs e)
        {
            // TODO Sarcina 8: bifat -> ScaleX negativ (aceeași mărime); debifat -> ScaleX pozitiv
        }

        // ---------- Sarcina 5. Textul, cu validare (A35) ----------
        private void BtnAplicaText_Click(object sender, RoutedEventArgs e)
        {

            string trimmed = TxtTextNou.Text.Trim();
            if (trimmed.Length > LungimeMaximaText || trimmed.Length <= 0)
            {
                MessageBox.Show("Date incorecte");
                TxtTextNou.Focus();
                return;
            }
            TxtAutocolant.Text = trimmed;
        }

        // ---------- Sarcina 6. Straturi (A33) ----------
        private void BtnStrat_Click(object sender, RoutedEventArgs e)
        {
            // TODO Sarcina 6: compară Panel.GetZIndex(Autocolant) cu Panel.GetZIndex(AutocolantFix)
            //                 și mută autocolantul sub / deasupra celui galben cu Panel.SetZIndex.
            //                 Schimbă și textul butonului BtnStrat.
            if (Panel.GetZIndex(Autocolant) > Panel.GetZIndex(AutocolantFix))
            {
                Panel.SetZIndex(Autocolant, 0);   // sub cel galben
                BtnStrat.Content = "Autocolantul deasupra celui galben";
            }
            else
            {
                // completează: readu autocolantul deasupra și schimbă textul butonului
            }

        }

        // ---------- Sarcina 6. Efecte (A34) ----------
        private void SldOpacitate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // TODO Sarcina 6: Autocolant.Opacity și textul TxtOpacitate în procente
        }

        private void ChkUmbra_Changed(object sender, RoutedEventArgs e)
        {
            // TODO Sarcina 6: bifat -> Autocolant.Effect = new DropShadowEffect { ... };
            //                 debifat -> Autocolant.Effect = null;
        }

        // ---------- Sarcina 8 (avansat). Evidențierea la mouse ----------
        // TODO Sarcina 8: creează metodele Autocolant_MouseEnter și Autocolant_MouseLeave
        //                 (argumentul este MouseEventArgs) și leagă-le în XAML.

        // ---------- Sarcina 9 (avansat). Folia de protecție ----------
        private void ChkFolie_Changed(object sender, RoutedEventArgs e)
        {
            // TODO Sarcina 9: afișează sau ascunde Folie (Visibility.Visible / Visibility.Collapsed)
        }

        // ---------- Sarcina 7. Revenirea la starea inițială ----------
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            // TODO Sarcina 7: readu Slider-ele la valorile inițiale (ValueChanged face restul),
            //                 debifează CheckBox-urile, pune TextInitial pe autocolant,
            //                 golește TxtTextNou și readu autocolantul deasupra celui galben.
        }
    }
}
