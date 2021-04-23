import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { AppConfig } from '../../app-config';

@Injectable()
export class ConfigService {
    constructor(private http: HttpClient,
        private appConfig: AppConfig) { }

    load(): Promise<void> {
        debugger;
        const appSettings = `/settings/appsettings.json`;
        const promise = this.http.get<AppConfig>(appSettings)
            .toPromise()
            .then(config => this.setConfig(config));

        return promise;
    }

    private setConfig(config: AppConfig): void {
        debugger;
        this.appConfig.appSettings = config.appSettings;
    }
}