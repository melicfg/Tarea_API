using Tarea.Clases;

namespace Tarea.Memoria
{
    public class Datos
    {
        private static List<TipoDeJuego> ListaTiposDeJuego = new List<TipoDeJuego>();
        private static List<Juego> ListaJuegos = new List<Juego>();

        public Datos()
        {
            if (ListaTiposDeJuego.Count == 0)
            {
                ListaTiposDeJuego = new List<TipoDeJuego>
                {
                    new TipoDeJuego { idTipo = 1, descripcion = "Aventura" },
                    new TipoDeJuego { idTipo = 2, descripcion = "Acción" },
                    new TipoDeJuego { idTipo = 3, descripcion = "Estrategia" }
                };
            }

            if (ListaJuegos.Count == 0)
            {
                ListaJuegos = new List<Juego>
                {
                    new Juego { Id_Juego = 1, Serial_Number = 123, Anio_Publicacion = 2020, Casa_Fabricante = "Fabricante A", Tipo_De_Juego = new List<TipoDeJuego> { ListaTiposDeJuego[0], ListaTiposDeJuego[2] } },
                    new Juego { Id_Juego = 2, Serial_Number = 456, Anio_Publicacion = 2019, Casa_Fabricante = "Fabricante B", Tipo_De_Juego = new List<TipoDeJuego> { ListaTiposDeJuego[0], ListaTiposDeJuego[1], ListaTiposDeJuego[2] } }
                };
            }
        }
        public void agregarJuego(Juego juego)
        {
            ListaJuegos.Add(juego);
        }


        public void agregarTipo(TipoDeJuego tipo)
        {
            ListaTiposDeJuego.Add(tipo);
        }

        public List<Juego> obtenerJuegos()
        {
            return ListaJuegos;
        }

        public List<TipoDeJuego> obtenerListaTipos()
        {
            return ListaTiposDeJuego;
        }

        public Juego buscarJuego(int id)
        {
            Juego juego = ListaJuegos.FirstOrDefault(j => j.Id_Juego == id);

            return juego;
        }

        public void eliminarJuego(int id)
        {
            Juego juego = ListaJuegos.FirstOrDefault(j => j.Id_Juego == id);

            ListaJuegos.Remove(juego);
        }

        public void editarJuego(int id, Juego nuevoJuego)
        {
            Juego juego = ListaJuegos.FirstOrDefault(j => j.Id_Juego == id);
            int indice = ListaJuegos.IndexOf(juego);

            ListaJuegos[indice].Id_Juego = nuevoJuego.Id_Juego;
            ListaJuegos[indice].Serial_Number = nuevoJuego.Serial_Number;
            ListaJuegos[indice].Anio_Publicacion = nuevoJuego.Anio_Publicacion;
            ListaJuegos[indice].Casa_Fabricante = nuevoJuego.Casa_Fabricante;
            ListaJuegos[indice].Tipo_De_Juego = nuevoJuego.Tipo_De_Juego;

        }

        public List<TipoDeJuego> obtenerTipos(int id)
        {
            Juego juego = ListaJuegos.FirstOrDefault(j => j.Id_Juego == id);

            return juego.Tipo_De_Juego;
        }

        public void agregarTipos(int id, TipoDeJuego tipo)
        {
            Juego juego = ListaJuegos.FirstOrDefault(j => j.Id_Juego == id);
            int indice = ListaJuegos.IndexOf(juego);
            ListaJuegos[indice].Tipo_De_Juego.Add(tipo);
        }

        public void eliminarTipos(int id, List<int> listaId)
        {
            Juego juego = ListaJuegos.FirstOrDefault(j => j.Id_Juego == id);
            int indice = ListaJuegos.IndexOf(juego);

            foreach (int i in listaId)
            {
                if (indice >= 0)
                {
                    TipoDeJuego? tipoDeJuego = ListaJuegos[indice].Tipo_De_Juego.FirstOrDefault(T => T.idTipo == i);

                    if (tipoDeJuego != null)
                    {
                        ListaJuegos[indice].Tipo_De_Juego.Remove(tipoDeJuego);
                    }
                }
            }
        }

        public void editarTipos(int idJuego, int idTipo, TipoDeJuego tipoNuevo)
        {
            Juego juego = ListaJuegos.FirstOrDefault(j => j.Id_Juego == idJuego);
            int indiceJuego = ListaJuegos.IndexOf(juego);
            TipoDeJuego? tipoDeJuego = ListaJuegos[indiceJuego].Tipo_De_Juego.FirstOrDefault(T => T.idTipo == idTipo);
            int indiceTipo = ListaJuegos.IndexOf(juego);
            int indiceTipoJuego = ListaJuegos[indiceJuego].Tipo_De_Juego.IndexOf(tipoDeJuego);

            ListaJuegos[indiceTipo].Tipo_De_Juego[indiceTipoJuego] = tipoNuevo;
            ListaTiposDeJuego[indiceTipo] = tipoNuevo;

        }


        //public List<TipoDeJuego> obtenerTipos(int id)
        //{
        //    Juego juego = ListaJuegos.FirstOrDefault(j => j.Id_Juego == id);

        //    List<TipoDeJuego> listaDeTipos = new List<TipoDeJuego>();

        //    foreach (int j in juego.Tipo_De_Juego) 
        //    {
        //        TipoDeJuego tipo = ListaTiposDeJuego.FirstOrDefault(t => t.idTipo == id);
        //        listaDeTipos.Add(tipo);  
        //    }

        //    return listaDeTipos;
        //}
    }
}
