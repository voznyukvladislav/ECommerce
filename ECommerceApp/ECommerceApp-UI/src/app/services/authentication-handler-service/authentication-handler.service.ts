import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { UserInfo } from 'src/app/data/userInfo';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationHandlerService {

  userInfoSubject: Subject<UserInfo> = new Subject();
  isAuthenticatedSubject: Subject<boolean> = new Subject();

  userInfo: UserInfo = new UserInfo();
  isAuthenticated: boolean = false;

  constructor() { 
    this.userInfo.role = localStorage.getItem("userInfo.role")!;
    this.userInfo.name = localStorage.getItem("userInfo.name")!;
    this.userInfo.surname = localStorage.getItem("userInfo.surname")!;
    this.userInfo.login = localStorage.getItem("userInfo.login")!;
    this.userInfo.email = localStorage.getItem("userInfo.email")!;
    this.userInfo.phone = localStorage.getItem("userInfo.phone")!;
    this.isAuthenticated = localStorage.getItem("userInfo.isAuthenticated")! == 'true' ? true : false;

    this.userInfoSubject.next(this.userInfo);
    this.isAuthenticatedSubject.next(this.isAuthenticated);
  }

  getUserInfo(): Subject<UserInfo> {
    return this.userInfoSubject;
  }

  getAuthenticationStatus(): Subject<boolean> {
    return this.isAuthenticatedSubject;
  }

  Authenticate(userInfo: UserInfo, storage: Storage) : void {
    storage.setItem("userInfo.isAuthenticated", "true");
    
    storage.setItem("userInfo.name", userInfo.name);
    storage.setItem("userInfo.surname", userInfo.surname);
    storage.setItem("userInfo.email", userInfo.email);
    storage.setItem("userInfo.login", userInfo.login);
    storage.setItem("userInfo.phone", userInfo.phone);
    storage.setItem("userInfo.role", userInfo.role);

    this.userInfo = userInfo;
    this.isAuthenticated = true;
    this.userInfoSubject.next(this.userInfo);
    this.isAuthenticatedSubject.next(this.isAuthenticated);
}

  logOut(storage: Storage) : void {
    storage.setItem("userInfo.isAuthenticated", "false");
    
    storage.setItem("userInfo.name", "");
    storage.setItem("userInfo.surname", "");
    storage.setItem("userInfo.email", "");
    storage.setItem("userInfo.login", "");
    storage.setItem("userInfo.phone", "");
    storage.setItem("userInfo.role", "");

    this.userInfo = new UserInfo();
    this.isAuthenticated = false;
    this.userInfoSubject.next(this.userInfo);
    this.isAuthenticatedSubject.next(this.isAuthenticated);
  }

  static getUserInfo(storage: Storage): UserInfo {
    let userInfo = new UserInfo();
    userInfo.name = storage.getItem("userInfo.name")!;
    userInfo.surname = storage.getItem("userInfo.surname")!;
    userInfo.email = storage.getItem("userInfo.email")!;
    userInfo.login = storage.getItem("userInfo.login")!;
    userInfo.phone = storage.getItem("userInfo.phone")!;
    userInfo.role = storage.getItem("userInfo.role")!;

    return userInfo;
  }

  static getAuthenticationStatus(storage: Storage): boolean {
    return storage.getItem("userInfo.isAuthenticated") == "true" ? true : false;
  }
}