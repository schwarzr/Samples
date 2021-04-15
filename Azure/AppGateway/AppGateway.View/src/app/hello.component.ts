import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { OAuthService } from "angular-oauth2-oidc";

@Component({
    selector: "hello",
    templateUrl: "./hello.component.html"
})
export class HelloComponent{

    constructor(private client: HttpClient, private oauthService: OAuthService) {
    }

    public serviceResponse?: string;

    public async getResponse(): Promise<void>{
        var response = await this.client.get("https://localhost:5003/Hello",
            {
                responseType: "text",
                headers: {Authorization: "BEARER " + this.oauthService.getAccessToken() }
            }).toPromise();

        this.serviceResponse = response;
    }
}