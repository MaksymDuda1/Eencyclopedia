import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { LocalService } from "../localService";

@Injectable({ providedIn: "root" })
export class AuthTokenAddInetrceptor implements HttpInterceptor {
    constructor(private localService: LocalService) {

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let token = this.localService.get(LocalService.AuthTokenName);

        if (token) {
            req = req.clone({
                setHeaders: { Authorization: 'Bearer ${token}' }
            });
        }

        if (req.url.endsWith(':id') || req.url.endsWith(':id') ||
            req.url.endsWith(':id') || req.url.endsWith(':id')) {
            const cacheRequest = req.clone({
                setHeaders: {
                    'Cache-Control': 'no-cache, no-store, must-revalidate'
                }
            });
            return next.handle(cacheRequest);
        }


        return next.handle(req).pipe();
    }

}