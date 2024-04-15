using System;

public class SystemInfo
{
    public string CurrentDate => DateTime.Now.ToShortDateString();
    public string CurrentTime => DateTime.Now.ToShortTimeString();
    public string LoggedInUser { get; private set; }

    // Constructor para inicializar el usuario conectado
    public SystemInfo(string loggedInUser)
    {
        LoggedInUser = loggedInUser;
    }

    // Método para actualizar el usuario conectado si es necesario
    public void UpdateLoggedInUser(string newUser)
    {
        LoggedInUser = newUser;
    }
}