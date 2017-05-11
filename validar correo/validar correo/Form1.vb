Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'max cantidad de caracteres, incluyendo el dominio

        TextBox1.MaxLength = 32

        TextBox3.Text = ("ejemplo24-2@gmail.com")

        Label1.Visible = False


    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        TextBox2.Text = ""

        'validar entrada de numeros, letras,control, (-), (_)

        If Not Char.IsNumber(e.KeyChar) And Not Char.IsLetter(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "_" And Not e.KeyChar = "-" Then

            e.Handled = True

        End If


        'validar ingreso de solo un (-)

        If e.KeyChar = "-" And TextBox1.Text.IndexOf("-") > -1 Then


            e.Handled = True

            TextBox2.Text = ("Solo se permite un (-) en la cuenta")


        End If

        'validar ingreso de solo un (_)

        If e.KeyChar = "_" And TextBox1.Text.IndexOf("_") > -1 Then


            e.Handled = True

            TextBox2.Text = ("Solo se permite un (_) en la cuenta")

        End If

        'no se puede ingresar (_) y (-) seguidos 

        If e.KeyChar = "-" And TextBox1.Text.IndexOf("_") = TextBox1.Text.Length - 1 Then

            e.Handled = True

            TextBox2.Text = "El simbolo no puede ir aqui"

        End If

        If e.KeyChar = "_" And TextBox1.Text.IndexOf("-") = TextBox1.Text.Length - 1 Then

            e.Handled = True

            TextBox2.Text = "El simbolo no puede ir aqui"

        End If


    End Sub


    Private Sub TextBox1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Validated

        If TextBox1.Text.Length < 1 Then

            TextBox2.Text = "Ingrese correo"

            Exit Sub

        End If

        'validar cantidad de caracteres

        If TextBox1.Text.Length > TextBox1.MaxLength Then

            TextBox2.Text = ("La cuenda debe contener menos de 32 caracteres, incluyendo el dominio")

            Exit Sub

        End If

        'validar que en la ultima posicion no se encuentre un (-) o un (_)

        Dim ultima As Char = TextBox1.Text.Substring(TextBox1.Text.Length - 1)

        If ultima = "-" Or ultima = "_" Then

            TextBox2.Text = ("El caracter (" + CStr(ultima) + " ) no puede en la ultima posicion")

            Exit Sub

        End If


        Label1.Visible = True

        'correo es igual al usuario ingresado en el textbox1 mas el item seleccionado del combo de dominios

        TextBox2.Text = TextBox1.Text + CStr(ComboBox1.SelectedItem)

        TextBox1.Text = ""

        ComboBox1.Text = ""

    End Sub

   
End Class
