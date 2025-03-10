using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ankieta_preferencji;

public partial class MainWindow : Window
{
    private TextBox _imie;
    private Button _zatwierdz;
    private Button _podsumowanie;
    private TextBlock _wyswietl;
    private string _kategoriaValue;
    private TextBlock _kliknieto;
    
    public MainWindow()
    {
        InitializeComponent();
        
        _zatwierdz = this.FindControl<Button>("Zatwierdz");
        _podsumowanie = this.FindControl<Button>("Podsumowanie");
        _wyswietl = this.FindControl<TextBlock>("Wyswietl");
        _kliknieto = this.FindControl<TextBlock>("Kliknieto");
    }

    private void ZatwierdzClick(object? sender, RoutedEventArgs e)
    {
        _imie = this.FindControl<TextBox>("Imie");
        _kategoriaValue = (Kategoria.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "No selection";
        _kliknieto.Text = "<- Kliknięto";
    }
    
    private void PodsumowanieClick(object? sender, RoutedEventArgs e)
    {
        if (_imie is null  || _kategoriaValue is null)
        {
            _wyswietl.Text = "Na początku kliknij przycisk 'Zatwierdz'";
        }
        else
        {
            var ilosc = 0;
            var programowanieValue = Programowanie.IsChecked == true ? ilosc+=1 : ilosc+=0;
            var zwierzeValue = Zwierze.IsChecked == true ? ilosc+=1 : ilosc+=0;
            var sniadanieValue = Sniadanie.IsChecked == true ? ilosc+=1 : ilosc+=0;
        
            var content = $"Imię: {_imie.Text}\n" +
                          $"Wybrana kategoria: {_kategoriaValue}\n" +
                          $"'Tak' zostało zaznaczone: {ilosc} razy";

            _kliknieto.Text = "";
            _wyswietl.Text = content;
        }
    }
}