using ApiAsp.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApiAsp.Models
{
    public class Principal
    {
        public int Numero { get; set; }
        public string Mensaje { get; set; }

        static public DataTable Registrar(int Numero, string Mensaje)
        {
            BaseDatos _BaseDatos = new BaseDatos();
            DataTable _DataTable = new DataTable();

            string SentenciaSQL = "EXEC ChrisSaludo @Numero, @Mensaje";
            List<SqlParameter> Parametros = new List<SqlParameter>
            {
                new SqlParameter("@Numero", SqlDbType.Int) { Value = Numero },
                new SqlParameter("@Mensaje", SqlDbType.VarChar) { Value = Mensaje }
            };

            _DataTable = _BaseDatos.ObtenerDataTable(SentenciaSQL, Parametros);

            if (_DataTable != null && _DataTable.Rows.Count > 0)
            {
                return _DataTable;
            }
            else
            {
                return null;
            }
        }

        static public respuestaRequest Registrar2(int Numero, string Mensaje)
        {
            respuestaRequest rRequest = new respuestaRequest();
            SqlClass miSqlClass = new SqlClass();
            miSqlClass.conectar();

            string JSONString = string.Empty;
            DataTable dtInfo = new DataTable();


            //pasamos los parametros para mandarlos al sp
            List<parametro> parametros = new List<parametro>
            {
                new parametro() {nombre = "Numero", valor = Numero.ToString()},
                new parametro() {nombre = "Mensaje", valor =  Mensaje},

            };

            //parametro de salida del sp
            List<parametro> parametrosOutput = new List<parametro>
            {
                new parametro() {nombre = "Err", tipoValor = parametro.tipoValorSalida.int_},
                new parametro() {nombre = "ErrDescripcion", tipoValor = parametro.tipoValorSalida.string_}
            };


            miSqlClass.funcStoreProcedureConsult("ChrisSaludo2", ref dtInfo, parametros, parametrosOutput);

            if (parametrosOutput[0].valor == "1")
            {
                rRequest.Err = parametrosOutput[0].valor;
                rRequest.ErrDescripcion = parametrosOutput[1].valor;
            }


            if (dtInfo.Rows.Count > 0)
            {
                JSONString = JsonConvert.SerializeObject(dtInfo);
                rRequest.json = JSONString;
            }

            return rRequest;
        }

        static public respuestaRequest Registrar3(long Numero, string[] Datos)
        {
            respuestaRequest rRequest = new respuestaRequest();
            SqlClass miSqlClass = new SqlClass();
            miSqlClass.conectar();

            string JSONString = string.Empty;
            DataTable dtInfo = new DataTable();


            //pasamos los parametros para mandarlos al sp
            List<parametro> parametros = new List<parametro>
            {
                new parametro() {nombre = "Nombre",   valor =  Datos[0]},
                new parametro() {nombre = "ApellidoP", valor =  Datos[1]},
                new parametro() {nombre = "ApellidoM", valor =  Datos[2]},
                new parametro() {nombre = "Direccion", valor =  Datos[3]},
                new parametro() {nombre = "Telefono", valor = Numero.ToString()}

            };

            //parametro de salida del sp
            List<parametro> parametrosOutput = new List<parametro>
            {
                new parametro() {nombre = "Err", tipoValor = parametro.tipoValorSalida.int_},
                new parametro() {nombre = "ErrDescripcion", tipoValor = parametro.tipoValorSalida.string_}
            };


            miSqlClass.funcStoreProcedureConsult("Chris_Crear", ref dtInfo, parametros, parametrosOutput);

            if (parametrosOutput[0].valor == "1")
            {
                rRequest.Err = parametrosOutput[0].valor;
                rRequest.ErrDescripcion = parametrosOutput[1].valor;
            }

            if (parametrosOutput[0].valor == "3")
            {
                rRequest.Err = parametrosOutput[0].valor;
                rRequest.ErrDescripcion = parametrosOutput[1].valor;
            }

            if (dtInfo.Rows.Count > 0)
            {
                // Regresar Lista
                JSONString = JsonConvert.SerializeObject(dtInfo);
                rRequest.json = JSONString;
            }

            return rRequest;
        }

        static public respuestaRequest Registrar4(long[] Numero, string[] Datos)
        {
            respuestaRequest rRequest = new respuestaRequest();
            SqlClass miSqlClass = new SqlClass();
            miSqlClass.conectar();

            string JSONString = string.Empty;
            DataTable dtInfo = new DataTable();


            //pasamos los parametros para mandarlos al sp
            List<parametro> parametros = new List<parametro>
            {
                new parametro() {nombre = "Id",        valor = Numero[0].ToString() },
                new parametro() {nombre = "Nombre",   valor =  Datos[0]},
                new parametro() {nombre = "ApellidoP", valor =  Datos[1]},
                new parametro() {nombre = "ApellidoM", valor =  Datos[2]},
                new parametro() {nombre = "Direccion", valor =  Datos[3]},
                new parametro() {nombre = "Telefono",  valor = Numero[1].ToString()}

            };

            //parametro de salida del sp
            List<parametro> parametrosOutput = new List<parametro>
            {
                new parametro() {nombre = "Err", tipoValor = parametro.tipoValorSalida.int_},
                new parametro() {nombre = "ErrDescripcion", tipoValor = parametro.tipoValorSalida.string_}
            };


            miSqlClass.funcStoreProcedureConsult("Chris_Update", ref dtInfo, parametros, parametrosOutput);

            if (parametrosOutput[0].valor == "1")
            {
                rRequest.Err = parametrosOutput[0].valor;
                rRequest.ErrDescripcion = parametrosOutput[1].valor;
            }

            if (parametrosOutput[0].valor == "3")
            {
                rRequest.Err = parametrosOutput[0].valor;
                rRequest.ErrDescripcion = parametrosOutput[1].valor;
            }

            if (dtInfo.Rows.Count > 0)
            {
                // Regresar Lista
                JSONString = JsonConvert.SerializeObject(dtInfo);
                rRequest.json = JSONString;
            }

            return rRequest;
        }

        static public respuestaRequest Registrar5(int Numero)
        {
            respuestaRequest rRequest = new respuestaRequest();
            SqlClass miSqlClass = new SqlClass();
            miSqlClass.conectar();

            string JSONString = string.Empty;
            DataTable dtInfo = new DataTable();


            //pasamos los parametros para mandarlos al sp
            List<parametro> parametros = new List<parametro>
            {
                new parametro() {nombre = "Id", valor = Numero.ToString()},
            };

            //parametro de salida del sp
            List<parametro> parametrosOutput = new List<parametro>
            {
                new parametro() {nombre = "Err", tipoValor = parametro.tipoValorSalida.int_},
                new parametro() {nombre = "ErrDescripcion", tipoValor = parametro.tipoValorSalida.string_}
            };


            miSqlClass.funcStoreProcedureConsult("Chris_Deactivate", ref dtInfo, parametros, parametrosOutput);

            if (parametrosOutput[0].valor == "1")
            {
                rRequest.Err = parametrosOutput[0].valor;
                rRequest.ErrDescripcion = parametrosOutput[1].valor;
            }

            if (dtInfo.Rows.Count > 0)
            {
                JSONString = JsonConvert.SerializeObject(dtInfo);
                rRequest.json = JSONString;
            }

            return rRequest;
        }

        static public respuestaRequest verTabla(int Numero)
        {
            respuestaRequest rRequest = new respuestaRequest();
            SqlClass miSqlClass = new SqlClass();
            miSqlClass.conectar();

            string JSONString = string.Empty;
            DataTable dtInfo = new DataTable();


            //pasamos los parametros para mandarlos al sp
            List<parametro> parametros = new List<parametro>
            {
                new parametro() {nombre = "Filtro", valor = Numero.ToString()},
            };

            //parametro de salida del sp
            List<parametro> parametrosOutput = new List<parametro>
            {
                new parametro() {nombre = "Err", tipoValor = parametro.tipoValorSalida.int_},
                new parametro() {nombre = "ErrDescripcion", tipoValor = parametro.tipoValorSalida.string_}
            };


            miSqlClass.funcStoreProcedureConsult("Chris_Tabla", ref dtInfo, parametros, parametrosOutput);

            if (parametrosOutput[0].valor == "1")
            {
                rRequest.Err = parametrosOutput[0].valor;
                rRequest.ErrDescripcion = parametrosOutput[1].valor;
            }

            if (dtInfo.Rows.Count > 0)
            {
                JSONString = JsonConvert.SerializeObject(dtInfo);
                rRequest.json = JSONString;
            }

            return rRequest;
        }

        static public respuestaRequest verResultado(string Busqueda)
        {
            respuestaRequest rRequest = new respuestaRequest();
            SqlClass miSqlClass = new SqlClass();
            miSqlClass.conectar();

            string JSONString = string.Empty;
            DataTable dtInfo = new DataTable();


            //pasamos los parametros para mandarlos al sp
            List<parametro> parametros = new List<parametro>
            {
                new parametro() {nombre = "Busqueda", valor = Busqueda},
            };

            //parametro de salida del sp
            List<parametro> parametrosOutput = new List<parametro>
            {
                new parametro() {nombre = "Err", tipoValor = parametro.tipoValorSalida.int_},
                new parametro() {nombre = "ErrDescripcion", tipoValor = parametro.tipoValorSalida.string_}
            };


            miSqlClass.funcStoreProcedureConsult("Chris_Search", ref dtInfo, parametros, parametrosOutput);

            if (parametrosOutput[0].valor == "1")
            {
                rRequest.Err = parametrosOutput[0].valor;
                rRequest.ErrDescripcion = parametrosOutput[1].valor;
            }

            if (dtInfo.Rows.Count > 0)
            {
                JSONString = JsonConvert.SerializeObject(dtInfo);
                rRequest.json = JSONString;
            }

            return rRequest;
        }

        static public respuestaRequest verPersona(int Estatus)
        {
            respuestaRequest rRequest = new respuestaRequest();
            SqlClass miSqlClass = new SqlClass();
            miSqlClass.conectar();

            string JSONString = string.Empty;
            DataTable dtInfo = new DataTable();


            //pasamos los parametros para mandarlos al sp
            List<parametro> parametros = new List<parametro>
            {
                new parametro() {nombre = "estatus", valor = Estatus.ToString()},
            };

            //parametro de salida del sp
            List<parametro> parametrosOutput = new List<parametro>
            {
                new parametro() {nombre = "Err", tipoValor = parametro.tipoValorSalida.int_},
                new parametro() {nombre = "ErrDescripcion", tipoValor = parametro.tipoValorSalida.string_}
            };


            miSqlClass.funcStoreProcedureConsult("Ver_Persona", ref dtInfo, parametros, parametrosOutput);

            if (parametrosOutput[0].valor == "1")
            {
                rRequest.Err = parametrosOutput[0].valor;
                rRequest.ErrDescripcion = parametrosOutput[1].valor;
            }

            if (dtInfo.Rows.Count > 0)
            {
                JSONString = JsonConvert.SerializeObject(dtInfo);
                rRequest.json = JSONString;
            }

            return rRequest;
        }

        static public respuestaRequest SeleccionarPersona(int Id)
        {

            respuestaRequest rRequest = new respuestaRequest();
            SqlClass miSqlClass = new SqlClass();
            miSqlClass.conectar();

            string JSONString = string.Empty;
            DataTable dtInfo = new DataTable();


            //pasamos los parametros para mandarlos al sp
            List<parametro> parametros = new List<parametro>
            {
                new parametro() {nombre = "Id", valor = Id.ToString()},
            };

            //parametro de salida del sp
            List<parametro> parametrosOutput = new List<parametro>
            {
                new parametro() {nombre = "Err", tipoValor = parametro.tipoValorSalida.int_},
                new parametro() {nombre = "ErrDescripcion", tipoValor = parametro.tipoValorSalida.string_}
            };


            miSqlClass.funcStoreProcedureConsult("Seleccionar_Persona", ref dtInfo, parametros, parametrosOutput);

            if (parametrosOutput[0].valor == "1")
            {
                rRequest.Err = parametrosOutput[0].valor;
                rRequest.ErrDescripcion = parametrosOutput[1].valor;
            }

            if (dtInfo.Rows.Count > 0)
            {
                JSONString = JsonConvert.SerializeObject(dtInfo);
                rRequest.json = JSONString;
            }

            return rRequest;

        }
    }
}
