Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'max cantidad de caracteres, incluyendo el dominio

        TextBox1.MaxLength = 32

        TextBox3.Text = ("ejemplo24-2@gmail.com")

        Label1.Visible = False


    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        TextBox2.Text = ""

        'validar entrada de numeros, letras,control, (-), (_), (.), (@)

        If Not Char.IsNumber(e.KeyChar) And Not Char.IsLetter(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "_" And Not e.KeyChar = "-" And Not e.KeyChar = "." And Not e.KeyChar = "@" Then

            e.Handled = True

        End If

        'no permitir el ingreso del (.) o el (@) en la primera posicion 

        Dim pos As Integer = TextBox1.SelectionStart

        If pos = 0 And (e.KeyChar = "@" Or e.KeyChar = ".") Then

            TextBox2.Text = ("No se puede ingresar este valor en la primer posicion")

            e.Handled = True

            Exit Sub

        End If

        'validar ingreso de solo un (@)

        If e.KeyChar = "@" And TextBox1.Text.IndexOf("@") > -1 Then

            e.Handled = True

            TextBox2.Text = ("Solo se permite un (@) en la cuenta")

            Exit Sub

        End If

        'ingresar el punto solo en el dominio, despues del (@)

        If e.KeyChar = "." And TextBox1.Text.IndexOf("@") = -1 Then

            TextBox2.Text = "El punto debe ir despues del (@) en el dominio."

            e.Handled = True

        End If

        'si el punto esta al lado del arroba tampoco ingresa

        If e.KeyChar = "." And TextBox1.Text.IndexOf("@") = TextBox1.Text.Length - 1 Then

            e.Handled = True

            TextBox2.Text = "El punto no puede ir aqui"

        End If

        'validar ingreso de solo un (.)

        If e.KeyChar = "." And TextBox1.Text.IndexOf(".") > -1 Then

        
            e.Handled = True

            TextBox2.Text = ("Solo se permite un (.) en la cuenta")

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

        'no ingresar los simbolos (_) o (-) despues del (@)

        If (e.KeyChar = "-" Or e.KeyChar = "_") And TextBox1.Text.IndexOf("@") > 1 Then

            e.Handled = True

            TextBox2.Text = "El simbolo no puede ir aqui"

        End If
    End Sub

    Private Sub TextBox1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Validated

        If TextBox1.Text.Length < 1 Then Exit Sub

        'validar cantidad de caracteres

        If TextBox1.Text.Length > TextBox1.MaxLength Then

            TextBox2.Text = ("La cuenda debe contener menos de 32 caracteres, incluyendo el dominio")

            Exit Sub

        End If
        'validar que en la ultima posicion no se encuentre un (.) o un (@)

        Dim ultima As Char = TextBox1.Text.Substring(TextBox1.Text.Length - 1)

        If ultima = "@" Or ultima = "." Then

            TextBox2.Text = ("El caracter (" + CStr(ultima) + " ) no puede en la ultima posicion")

            Exit Sub

        End If

        'validar que contenga el (@) y el (.)

        If TextBox1.Text.IndexOf("@") = -1 And TextBox1.Text.IndexOf(".") Then

            TextBox2.Text = "Debe contener un arroba(@) y un punto (.)"

            Exit Sub
         
        End If
        'si esta el arroba tambien el punto

        If TextBox1.Text.IndexOf(".") = -1 Then

            TextBox2.Text = "El dominio debe contener un punto"

            Exit Sub

        End If

        Label1.Visible = True

        TextBox2.Text = TextBox1.Text

        TextBox1.Text = ""


    End Sub

   
End Class
