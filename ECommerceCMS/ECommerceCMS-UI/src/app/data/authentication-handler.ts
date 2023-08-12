export class AuthenticationHandler {
    static Authenticate(data: any, storage: Storage) : void {
        storage.setItem("UserDTO.Id", data.id);
        storage.setItem("UserDTO.Login", data.login);
        storage.setItem("UserDTO.Email", data.email);
        storage.setItem("UserDTO.Name", data.name);
        storage.setItem("UserDTO.Surname", data.surname);
        storage.setItem("UserDTO.Phone", data.phone);
        storage.setItem("UserDTO.Role", data.role);
    }

    static LogOut(storage: Storage) {
        storage.clear();
    }
}