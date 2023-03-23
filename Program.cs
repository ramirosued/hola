using System.Collections.Generic;
Dictionary<string, int> dicPlataCurso = new Dictionary<string, int>();
string curso;
int cantAlumnos, dineroIngresado, dineroAcum, totalDinero = 0, menu;
bool cursoPosible;

menu = funcionMenu("Elige una opcion");
while (menu != 3)
{
    switch (menu)
    {
        case 1:
            dineroAcum = 0;
            do{
                curso = ingresarTexto("Ingrese el curso del que desea ingresar dinero").ToUpper();
                cursoPosible=validarExistenciaCurso(dicPlataCurso,curso);
            }while(!cursoPosible);
            cantAlumnos = ingresarEntero("¿Cuantos alumnos tiene el curso?");
            for (int i = 0; i < cantAlumnos; i++)
            {
                dineroIngresado = ingresarEntero("Ingrese cuanto dinero desea regalar");
                dineroAcum += dineroIngresado;
                totalDinero += dineroIngresado;
            }
            dicPlataCurso.Add(curso, dineroAcum);
            menu = funcionMenu("Elige una opcion");
            break;
        case 2:
            mostrarEstadisticas(dicPlataCurso, totalDinero);
            menu = funcionMenu("Elige una opcion");
            break;
        case 3:
            break;
    }
}



int funcionMenu(string mensaje)
{
    int opcion;
    Console.WriteLine("1- Ingrese los importes de un curso");
    Console.WriteLine("2- Ver estadisticas");
    Console.WriteLine("3- Salir");

    Console.WriteLine(mensaje);
    opcion = int.Parse(Console.ReadLine());
    while (opcion < 0 || opcion > 3)
    {
        Console.WriteLine("Has ingresado mal la opcion, ingresala de nuevo");
        opcion = int.Parse(Console.ReadLine());
    }
    return opcion;
}
string ingresarTexto(string v)
{
    string texto;
    Console.WriteLine(v);
    texto = Console.ReadLine();
    return texto;
}
bool validarExistenciaCurso(Dictionary<string, int> dict, string key)
{
    bool keyPosible;
    keyPosible=dict.ContainsKey(key)==false;
    if(!keyPosible)Console.WriteLine("Ese curso ya está ingresado");
    return keyPosible;
}
int ingresarEntero(string v)
{
    int num;
    Console.WriteLine(v);
    num = int.Parse(Console.ReadLine());
    while (num < 0)
    {
        Console.WriteLine("Has ingresado mal el numero, vuelevlo a ingresar");
        num = int.Parse(Console.ReadLine());
    }
    return num;
}
void mostrarEstadisticas(Dictionary<string, int> dicPlataCurso, int totalDinero)
{
    int numMayor = 0;
    string mayorCurso = "";
    foreach (string curso in dicPlataCurso.Keys)
    {
        if (dicPlataCurso[curso] > numMayor)
        {
            numMayor = dicPlataCurso[curso];
            mayorCurso = curso;
        }
    }
    Console.WriteLine("El curso que mas plata puso fue el " + mayorCurso);
    Console.WriteLine("El promedio de plata que se regalo entre los cursos fue de " + totalDinero / dicPlataCurso.Count);
    Console.WriteLine("Entre todos los cursos regalaron $" + totalDinero);
    Console.WriteLine("La cantidad de cursos que participaron del regalo fueron " + dicPlataCurso.Count);
}
