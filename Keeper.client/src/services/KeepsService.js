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

    async getOne(id) {
        const res = await api.get(`api/keeps/${id}`)
        logger.log ('getting one keep from the service', res.data)
        AppState.activeKeep = res.data
        logger.log('active keep in the appstate success', AppState.activeKeep)
    }

    async deleteKeep(id){
        const res = await api.delete(`api/keeps/${id}`)
        AppState.keeps = AppState.keeps.filter(k => k.id != id)
    }

    async createKeep(keepData){
        let res = await api.post(`api/keeps`, keepData)
        logger.log('creating keep from the service', res.data)
        AppState.keeps.push(res.data)

    }

}

export const keepsService = new KeepsService()