import { HttpClientModule,  HttpErrorResponse } from '@angular/common/http';

import { APP_INITIALIZER, Injector, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConfigService } from './core/config/config.service';
import { CoreModule } from './core/core.module';
import { HomeModule } from './home/home.module';

export function configAndLogsServiceFactory(
  config: ConfigService,
  injector: Injector,

) {
  return () =>
    config.load()
      .catch((error: HttpErrorResponse) => {
        const router = injector.get(Router);
        if (error.status === 404) router.navigate(["/errors/404"]);
      })
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    CoreModule,
    HomeModule,
    BrowserAnimationsModule
  ],
  providers: [
    ConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: configAndLogsServiceFactory,
      deps: [
        ConfigService,
      ],
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
