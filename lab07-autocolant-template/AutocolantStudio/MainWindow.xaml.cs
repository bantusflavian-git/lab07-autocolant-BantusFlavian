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
        private void AplicaScala(RoutedPropertyChangedEventArgs<double> e)
        {
            // Sarcina 8 (avansat): mută această logică într-o metodă AplicaScala()
            if (!IsLoaded) return;

            ScalareAutocolant.ScaleX = e.NewValue;
            ScalareAutocolant.ScaleY = e.NewValue;

            TxtScala.Text = $"Mărime: {e.NewValue * 100:0}%";
        }
        private void SldScala_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            AplicaScala(e);
        }

        // ---------- Sarcina 8 (avansat). Oglindirea ----------
        private void ChkOglindit_Changed(object sender, RoutedEventArgs e)
        {
            ScalareAutocolant.ScaleX = ScalareAutocolant.ScaleX * -1;
        }

        // ---------- Sarcina 5. Textul, cu validare (A35) ----------
        private void BtnAplicaText_Click(object sender, RoutedEventArgs e)
        {

            string trimmed = TxtTextNou.Text.Trim();
            if (trimmed.Length > LungimeMaximaText || trimmed.Length <= 0)
            {
                MessageBox.Show("Date incorecte","Eroare", MessageBoxButton.OK,MessageBoxImage.Error);
                TxtTextNou.Focus();
                return;
            }
            TxtAutocolant.Text = trimmed;
            TxtTextNou.Text = trimmed;
        }

        // ---------- Sarcina 6. Straturi (A33) ----------
        private void BtnStrat_Click(object sender, RoutedEventArgs e)
        {

            if (Panel.GetZIndex(Autocolant) > Panel.GetZIndex(AutocolantFix))
            {
                Panel.SetZIndex(Autocolant, 0);   // sub cel galben
                BtnStrat.Content = "Autocolantul deasupra celui galben";
            }
            else
            {
                Panel.SetZIndex(Autocolant, Panel.GetZIndex(AutocolantFix) + 1);
                BtnStrat.Content = "Autocolantul sub cel galben";
            }

        }

        // ---------- Sarcina 6. Efecte (A34) ----------
        private void SldOpacitate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Autocolant.Opacity = e.NewValue;
            TxtOpacitate.Text = $"Opacitate: {e.NewValue}%";
        }

        private void ChkUmbra_Changed(object sender, RoutedEventArgs e)
        {
            if (ChkUmbra.IsChecked == true)
            {
                Autocolant.Effect = new DropShadowEffect { BlurRadius = 12, ShadowDepth = 4, Opacity = 0.4 };
            }
            else
            {
                Autocolant.Effect = null;
            }
        }

        private void Autocolant_MouseEnter(object sender, MouseEventArgs e)
        {
            Autocolant.BorderBrush = Brushes.DarkBlue;
        }

        private void Autocolant_MouseLeave(object sender, MouseEventArgs e)
        {
            Autocolant.BorderBrush = Brushes.White;
        }

        // ---------- Sarcina 9 (avansat). Folia de protecție ----------
        private void ChkFolie_Changed(object sender, RoutedEventArgs e)
        {
            // TODO Sarcina 9: afișează sau ascunde Folie (Visibility.Visible / Visibility.Collapsed)
            if (ChkFolie.IsChecked == true)
            {
                Folie.Visibility = Visibility.Visible;
            }
            else
            {
                Folie.Visibility = Visibility.Collapsed;
            }
        }

        // ---------- Sarcina 7. Revenirea la starea inițială ----------
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {

            TxtAutocolant.Text = "Salut, WPF!";
            SldOpacitate.Value = 1;
            SldX.Value = 0;
            SldY.Value = 0;
            ChkOglindit.IsChecked = false;
            TxtTextNou.Clear();
            SldUnghi.Value = -30;
            SldScala.Value = 1;
            ChkUmbra.IsChecked = false;
            ChkFolie.IsChecked = false;
            Panel.SetZIndex(Autocolant, 2);
            Panel.SetZIndex(AutocolantFix, 1);
            BtnStrat.Content = "Autocolantul sub cel galben";
        }
    }
}
