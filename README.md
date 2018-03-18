## Ecuador ID Validator

Validates Cedula and different types of RUC as a string extension.

*Valida documentos de tipo Cédula y diferentes tipos de RUC, como una extension de cadena de texto.*

------------

### Important (Importante)

Don't forget to donate to keep mantaining this package updated and bugs free.

*No olvides donar fondos para mantener este paquete actualizado y libre de bugs.*

[![](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=FTFYBE7RV4ZS4)

------------

#### Getting Started (Preparándose)

Install the package through Nuget package manager or command line:

*Instale el paquete por medio del administrador de paquetes de Nuget ó por medio de la linea de comando:*

```
Install-Package ecuador.id.validator -Version 1.0.0
```

[ecuador.id.validator Nuget Package](https://www.nuget.org/packages/ecuador.id.validator/) 

#### How it works? (¿Cómo funciona?)

Include a reference to the library.

*Incluya una referencia a la librería.*

```
using ecuador.id.validator;
```

Call the function.

*Llame a la función.*

```
  var document = "1234567890";
  var documentType = document.ValidateDocument();
```
If the validation is successful a `DocumentType` is returned.

*Si la validación es exitosa, un tipo de documento es retornado.*

```
  DocumentType.Cedula;
  DocumentType.RUC_Juridico;
  DocumentType.RUC_Natural;
  DocumentType.RUC_Publico;
```

If the validation fails, an exception is thrown.

*Si la validación no es exitosa, se lanza una excepción.*

```
EcuadorIdValidationException
```

#### Built With (Desarrollado con)

.NET Standard 2.0
