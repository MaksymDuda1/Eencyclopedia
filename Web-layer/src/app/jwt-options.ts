import { LocalService } from "../services/localService";

export function jwtFactory(localService: LocalService){
    return{
        tokenGetter: () => {
            return localService.get(LocalService.AuthTokenName);
        }
    }
}