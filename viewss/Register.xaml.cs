namespace kpullopaxiExamen.viewss;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        double monto = Convert.ToDouble(txtMontoInicial.Text);
        double pagoMensual = (CalcularMensual(monto));

        txtPagoMensual.Text = Convert.ToString(pagoMensual);
    }

    private void btnResumen_Clicked(object sender, EventArgs e)
    {
        string fecha = datePicker.Date.ToString("d");
        string pais = pickerPais.SelectedItem?.ToString();
        string ciudad = pickerCiudad.SelectedItem?.ToString();
        string montoInicial = txtMontoInicial.Text;
        string pagoMensual = txtPagoMensual.Text;

        string nombre = txtNombre.Text;
        string apellido = txtApellido.Text;
        string edad = txtEdad.Text;
        double montoTotal = CalcularTotal(Convert.ToDouble(txtMontoInicial.Text));

        string mensaje = $"Resumen:\n\n" +
                     $"Nombre: {nombre}\n" +
                     $"Apellido: {apellido}\n" +
                     $"Edad: {edad}\n\n" +
                     $"Fecha: {fecha}\n" +
                     $"Ciudad: {ciudad}\n" +
                     $"País: {pais}\n" +
                     $"Monto Inicial: {montoInicial}\n" +
                     $"Pago Mensual: {pagoMensual}\n" +
                      $"Pago Total: {montoTotal}\n";

        DisplayAlert("Datos Capturados", mensaje, "OK");
    }
    private double CalcularMensual(double monto)
    {

        double cuotas = (1500 - monto) / 4;
        double pagoMensual = ((cuotas * 0.04) + cuotas);

        //double pagoMensual = (1500 - monto )/4 +( 0.04*1500);


        return pagoMensual;
    }
    private double CalcularTotal(double monto)
    {

        double cuotas = (1500 - monto) / 4;
        double pagoMensual = ((cuotas * 0.04) + cuotas);
        double pagoTotal = (pagoMensual * 4) + monto;
        //double pagoMensual = (1500 - monto) / 4 + (0.04 * 1500);
        //double pagoTotal =(pagoMensual * 4) +monto;

        return pagoTotal;
    }

    private void txtMontoInicial_TextChanged(object sender, TextChangedEventArgs e)
    {
        validacion(txtMontoInicial.Text);

    }
    private void validacion(string valorCampo)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(valorCampo))
            {
                double monto = Convert.ToDouble(valorCampo);
                if (monto > 1500 || monto < 0)
                {
                    DisplayAlert("Valor incorrecto", "Ingrese valor menor al costo de curso", "ok");
                    txtMontoInicial.Text = "";
                }

            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    private void btnResumen_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Register());

    }

    private void btnResumen_Clicked_2(object sender, EventArgs e)
    {

    }
}
