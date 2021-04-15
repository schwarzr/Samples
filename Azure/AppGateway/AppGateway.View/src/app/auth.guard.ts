import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import {OAuthService} from "angular-oauth2-oidc";

@Injectable()
export class AuthGuard implements CanActivate
{
    constructor(private oauthService: OAuthService) {

    }

    async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> 
    {
        await this.oauthService.loadDiscoveryDocument();

        if(this.oauthService.hasValidAccessToken())
        {
            return true;
        }

        if (await this.oauthService.tryLogin()){
            return true;
        }

        this.oauthService.initLoginFlow();
        return false;

    }

}