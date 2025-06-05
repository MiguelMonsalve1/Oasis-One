using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace OasisOneBack.Clases
{
    public class Login
    {

        private OasisOneEntities dbsuper = new OasisOneEntities();

        public async Task<ResultadoLogin> LoginAsync(string correo, string contraseña)
        {
            var empleado = await dbsuper.Empleados.FirstOrDefaultAsync(e => e.Correo == correo && e.Contraseña == contraseña);

            if (empleado != null)
            {
                string token = Guid.NewGuid().ToString();

                var sesion = new Sesiones_Empleados
                {
                    Id_Empleado = empleado.Id_Empleado,
                    Fecha_Inicio = DateTime.Now,
                    Token = token
                };

                dbsuper.Sesiones_Empleados.Add(sesion);
                await dbsuper.SaveChangesAsync();

                return new ResultadoLogin
                {
                    EsValido = true,
                    Mensaje = "Login exitoso como empleado",
                    Rol = "Empleado",
                    Token = token,
                    Id = empleado.Id_Empleado
                };
            }

            var usuario = await dbsuper.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == correo && u.Contraseña == contraseña);

            if (usuario != null)
            {
                string token = Guid.NewGuid().ToString();

                var sesion = new Sesiones_Usuarios
                {
                    Id_Usuario = usuario.Id_Usuario,
                    Fecha_Inicio = DateTime.Now,
                    Token = token
                };

                dbsuper.Sesiones_Usuarios.Add(sesion);
                await dbsuper.SaveChangesAsync();

                return new ResultadoLogin
                {
                    EsValido = true,
                    Mensaje = "Login exitoso como usuario",
                    Rol = "Usuario",
                    Token = token,
                    Id = usuario.Id_Usuario
                };
            }

            return new ResultadoLogin
            {
                EsValido = false,
                Mensaje = "Credenciales incorrectas"
            };
        }

        public async Task<ResultadoRegistro> RegistrarUsuario(Usuarios usuarioNuevo)
        {
            var consultarUsuario = await dbsuper.Usuarios.FirstOrDefaultAsync(u => u.Correo == usuarioNuevo.Correo);

            if (consultarUsuario != null)
            {
                return new ResultadoRegistro
                {
                    Exito = false,
                    Mensaje = "Ya existe un usuario con ese correo"
                };
            }

            usuarioNuevo.Fecha_Registro = DateTime.Now;
            usuarioNuevo.Estado = true;

            dbsuper.Usuarios.Add(usuarioNuevo);
            await dbsuper.SaveChangesAsync();

            return new ResultadoRegistro
            {
                Exito = true,
                Mensaje = "Usuario registrado exitosamente",
                Id = usuarioNuevo.Id_Usuario
            };
        }


        public async Task<ResultadoRegistro> RegistrarEmpleado(Empleados empleadoNuevo)
        {
            var consultarEmpleado = await dbsuper.Empleados.FirstOrDefaultAsync(e => e.Correo == empleadoNuevo.Correo);

            if (consultarEmpleado != null)
            {
                return new ResultadoRegistro
                {
                    Exito = false,
                    Mensaje = "Ya existe un empleado con ese correo."
                };
            }

            empleadoNuevo.Estado = true;
            dbsuper.Empleados.Add(empleadoNuevo);
            await dbsuper.SaveChangesAsync();

            return new ResultadoRegistro
            {
                Exito = true,
                Mensaje = "Empleado registrado exitosamente.",
                Id = empleadoNuevo.Id_Empleado
            };
        }   

        public class ResultadoLogin
        {
            public bool EsValido { get; set; }
            public string Mensaje { get; set; }
            public string Rol { get; set; }
            public string Token { get; set; }
            public int? Id { get; set; }
        }

        public class ResultadoRegistro
        {
            public bool Exito { get; set; }
            public string Mensaje { get; set; }
            public int? Id { get; set; }
        }



    }
}
