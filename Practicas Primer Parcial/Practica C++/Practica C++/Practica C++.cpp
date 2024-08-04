#include <iostream>
#include <string>
//esta libreria para poder trabajar con vectores
#include <vector>
#include <algorithm>

using namespace std;

class Usuario {
private:
    int Id;
    string Nombre;
    string NombreUsuario;
    double Puntaje;

public:
    Usuario(int id, string nombre, string nombreUsuario, double puntaje)
        : Id(id), Nombre(nombre), NombreUsuario(nombreUsuario), Puntaje(puntaje) {}

    // Getters
    int getId() const 
    { 
        return Id; 
    }
    string getNombre() const 
    { 
        return Nombre; 
    }
    string getNombreUsuario() const 
    { 
        return NombreUsuario; 
    }
    double getPuntaje() const 
    { 
        return Puntaje; 
    }

    // Setters
    void setId(int id) 
    { 
        Id = id; 
    }
    void setNombre(const string& nombre) 
    { 
        Nombre = nombre; 
    }
    void setNombreUsuario(const string& nombreUsuario) 
    { 
        NombreUsuario = nombreUsuario; 
    }
    void setPuntaje(double puntaje) 
    { 
        Puntaje = puntaje; 
    }
};

// Lista de usuarios global
vector<Usuario> usuarios;

// Funciones
void Mostrar() {

    if (usuarios.empty()) {

        cout << "No hay usuarios para mostrar" << endl;
        return;

    }
    cout << "Lista de Usuarios:" << endl;
    for (const auto& usuario : usuarios) {
        cout << "ID: " << usuario.getId() 
             << ", Nombre: " << usuario.getNombre()
             << ", Nombre de Usuario: " << usuario.getNombreUsuario()
             << ", Puntaje: " << usuario.getPuntaje() << endl;
    }
}

void Anadir() {
    int id;
    string nombre, nombreUsuario;
    double puntaje;

    cout << "Ingrese ID: ";
    cin >> id;

    // Limpiar el buffer
    cin.ignore(); 

    cout << "Ingrese Nombre: ";
    getline(cin, nombre);
    cout << "Ingrese Nombre de Usuario: ";
    getline(cin, nombreUsuario);
    cout << "Ingrese Puntaje: ";
    cin >> puntaje;

    Usuario nuevoUsuario(id, nombre, nombreUsuario, puntaje);
    usuarios.push_back(nuevoUsuario);
    cout << "Usuario anadido con exito." << endl;
}

void Editar() {
    int id;
    cout << "Ingrese el ID del usuario a editar: ";
    cin >> id;

    auto it = find_if(usuarios.begin(), usuarios.end(), [id](const Usuario& u) { return u.getId() == id; });
    if (it != usuarios.end()) {
        string nombre, nombreUsuario;
        double puntaje;

        cout << "Ingrese el nuevo Nombre: ";

        cin.ignore();
        getline(cin, nombre);

        cout << "Ingrese el nuevo Nombre de Usuario: ";
        getline(cin, nombreUsuario);
        cout << "Ingrese el nuevo Puntaje: ";
        cin >> puntaje;

        it->setNombre(nombre);
        it->setNombreUsuario(nombreUsuario);
        it->setPuntaje(puntaje);

        cout << "Usuario editado con exito" << endl;
    }
    else {
        cout << "Usuario no encontrado" << endl;
    }
}

void Eliminar() {
    int id;
    cout << "Ingrese el ID del usuario a eliminar: ";
    cin >> id;

    //funcion que nos permite eliminar un elemento del vector, esta acompañado de una expresion lambda
    auto it = remove_if(usuarios.begin(), usuarios.end(), [id](const Usuario& u) { return u.getId() == id; });
    
    if (it != usuarios.end()) {
        usuarios.erase(it, usuarios.end());
        cout << "Usuario eliminado con exito" << endl;
    }
    else {
        cout << "Usuario no encontrado" << endl;
    }
}

void ModificarPuntaje() {
    int id;
    cout << "Ingrese el ID del usuario para modificar el puntaje: ";
    cin >> id;
    //para encontrar al elemento del vector
    auto it = find_if(usuarios.begin(), usuarios.end(), [id](const Usuario& u) { return u.getId() == id; });
    
    if (it != usuarios.end()) {
        double nuevoPuntaje;
        cout << "Ingrese el nuevo Puntaje: ";
        cin >> nuevoPuntaje;

        it->setPuntaje(nuevoPuntaje);

        cout << "Puntaje modificado con exito" << endl;
    }
    else {
        cout << "Usuario no encontrado" << endl;
    }
}

int main() {
    int op;

    do {
        cout << "Elija una opcion: " << endl;
        cout << "1.Mostrar Usuarios" << endl;
        cout << "2.Anadir Usuario" << endl;
        cout << "3.Editar Usuario" << endl;
        cout << "4.Eliminar Usuario" << endl;
        cout << "5.Modificar Puntaje" << endl;
        cout << "0.Salir" << endl;

        cin >> op;

        switch (op) {
        case 1:
            Mostrar();
            break;
        case 2:
            Anadir();
            break;
        case 3:
            Editar();
            break;
        case 4:
            Eliminar();
            break;
        case 5:
            ModificarPuntaje();
            break;
        case 0:
            cout << "Saliendo" << endl;
            break;
        default:
            cout << "Elegi algo bien pue" << endl;
            break;
        }
    } while (op != 0);

    return 0;
}
