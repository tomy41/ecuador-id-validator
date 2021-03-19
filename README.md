## Ecuador ID Validator

Validates Cedula and different types of RUC as a string extension.

*Valida documentos de tipo Cédula y diferentes tipos de RUC, como una extension de cadena de texto.*

------------

#### Getting Started (Preparándose)

Install the package through Nuget package manager or command line:

*Instale el paquete por medio del administrador de paquetes de Nuget ó por medio de la linea de comando:*

```
Install-Package ecuador.id.validator -Version 2.0.0
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
  DocumentType.Consumidor_Final;
```

If the validation fails, an exception is thrown.

*Si la validación no es exitosa, se lanza una excepción.*

```
EcuadorIdValidationException
```

To avoid wrapping the validation in a try-catch, call the boolean function.

*Llame a la función booleana para evitar el uso de try-catch*

```
  var document = "1234567890";
  if(document.IsDocumentValid())
  {
  }
```
You can also use the try-get function as a combination of the previous functions.

*También puede usar la función try-get como combinación de las anteriores funciones*

```
  var document = "1234567890";
  if(EcuadorIdValidator.TryGetDocumentType(document, out DocumentType? resultType))
  {
  }
```
#### Built With (Desarrollado con)

.NET Standard 2.0

### Icon
Icon by https://icons8.com/