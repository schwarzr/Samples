import { LocationStrategy, PathLocationStrategy } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AuthConfig, OAuthModule, OAuthService } from 'angular-oauth2-oidc';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthGuard } from './auth.guard';
import { HelloComponent } from './hello.component';

export const AUTHCONFIG: AuthConfig =
{
    clientId: "e43d7097-55e4-4369-9650-124601197dc6",
    issuer: AppSettings.getValue("IdentityUrl"),
    scope: "openid",
    disableAtHashCheck: true,
    requireHttps: false,
}

@NgModule({
    declarations: [
        AppComponent,
        HelloComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        FormsModule,
        OAuthModule.forRoot(),
        HttpClientModule
    ],
    providers: [AuthGuard],
    bootstrap: [AppComponent]
})
export class AppModule {

    constructor(oauthService: OAuthService, locationStrategy: LocationStrategy) {
        oauthService.configure(AUTHCONFIG);

        oauthService.redirectUri = window.location.origin + locationStrategy.getBaseHref();
    }
}
