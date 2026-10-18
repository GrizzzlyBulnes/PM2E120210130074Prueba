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

        if (!double.TryParse(txtPeso.Text, out double peso))
        {
            await DisplayAlert("Error", "Por favor ingrese valores numericos validos.", "Ok");
            return;
        }

        if (pckDestino.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Seleccione una zona de destino.", "Ok");
            return;
        }


        double envio = pckDestino.SelectedIndex.ToString() switch
        {
            "0" => 50 + (peso * 50),  // zona local
            "1" => 85 + (peso * 85), // zona nacional
            "2" => 150 + (peso * 150), // zona internacional
            _ => 0
        };

        if (chkServicioExpres.IsChecked)
        {
            envio += 100;
        }

        lblValorPaquete.Text = $"L. {envio:F2}";
        lbl.Text = "Costo total del envío";

        lblResultado.Text =
            $"Descripción: {txtDescripcion.Text}\n" +
            $"Peso: {peso:F2} kg\n" +
            $"Destino: {pckDestino.Items[pckDestino.SelectedIndex]}\n" +
            $"Servicio Exprés: {(chkServicioExpres.IsChecked ? "Sí" : "No")}";

        brResultado.IsVisible = true;



        //Por ultimo, muestra la tarjeta que estaba oculta 
        brResultado.IsVisible = true;

    }

}