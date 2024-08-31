import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { LinqService } from './clients/services/linq.service';
import { LinqAdapter } from './clients/adapters/linq.adapter';
import { StoreService } from './clients/services/store.service';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    {provide: LinqService},
    {provide: StoreService},
    {provide: LinqAdapter},
  ]
};
