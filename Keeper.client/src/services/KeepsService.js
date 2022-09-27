import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class KeepsService {

    async getKeeps(){
        const res = await api.get('api/keeps')
        // logger.log(res.data, 'getting keeps from the service')
        AppState.keeps = res.data
        // logger.log('Checking the appstate contents', AppState.keeps)
    }
}

export const keepsService = new KeepsService()