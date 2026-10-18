namespace PM2E120210130074Prueba;

public partial class CalculadoradeEnvios : ContentPage
{
	public CalculadoradeEnvios()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //TryParse intenta convertir el texto a numero
        //Tambien validamos que la altura sea mayor que 0 (evita dividir)

        if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
        {
            await DisplayAlert("Error", "Ingrese la descripcion del paquete.", "Ok");
            return;
        }

        String textoPeso = txtPeso.Text.Replace(',', '.');

        if (!double.TryParse(textoPeso, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture,
            out double peso) || peso <= 0)

        {
            await DisplayAlert("Error", "Por favor ingrese un peso numerico mayor que 0.", "Ok");
            return;
        }

        if (pckDestino.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Seleccione una zona de destino.", "Ok");
            return;
        }


        double tarifa = pckDestino.SelectedIndex.ToString() switch
        {
            "0" => 50.00,  // zona local
            "1" => 85.00, // zona nacional
            "2" => 150.00, // zona internacional
            _ => 0
        };

        double recargoExpres = chkServicioExpres.IsChecked ? 100.00 : 0;

        double envio = (peso * tarifa) + recargoExpres;


        lblValorPaquete.Text = $"L. {envio:F2}";
        lbl.Text = "Costo total del envio";

        lblResultado.Text =
            $"Descripcion: {txtDescripcion.Text}\n" +
            $"Peso: {peso:F2} kg\n" +
            $"Destino: {pckDestino.Items[pckDestino.SelectedIndex]}\n" +
            $"Tarifa por kg: L.{tarifa:F2}\n" +
            $"Servicio Expres: L. {recargoExpres:F2}";


        if(envio < 300.00)
        {
            brResultado.BackgroundColor = Color.FromArgb("#DCFCE7");
        }
        else
        {
            brResultado.BackgroundColor = Color.FromArgb("E0F2FE");
        }

      

        //Por ultimo, muestra la tarjeta que estaba oculta 
        brResultado.IsVisible = true;

    }

}