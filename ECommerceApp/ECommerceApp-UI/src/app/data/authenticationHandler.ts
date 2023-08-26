import { UserInfo } from "./userInfo";

export class AuthenticationHandler {
    
    static Authenticate(userInfo: UserInfo, storage: Storage) : void {
        storage.setItem("userInfo.isAuthenticated", "true");
        
        storage.setItem("userInfo.name", userInfo.name);
        storage.setItem("userInfo.surname", userInfo.surname);
        storage.setItem("userInfo.email", userInfo.email);
        storage.setItem("userInfo.login", userInfo.login);
        storage.setItem("userInfo.phone", userInfo.phone);
        storage.setItem("userInfo.role", userInfo.role);
    }

    static LogOut(storage: Storage) : void {
        storage.setItem("userInfo.isAuthenticated", "false");
        
        storage.setItem("userInfo.name", "");
        storage.setItem("userInfo.surname", "");
        storage.setItem("userInfo.email", "");
        storage.setItem("userInfo.login", "");
        storage.setItem("userInfo.phone", "");
        storage.setItem("userInfo.role", "");
    }
}