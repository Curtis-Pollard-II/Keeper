import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class VaultKeepsService {


    async getVaultKeeps(id){
        const res = await api.get(`api/vaults/${id}/keeps`)
        logger.log('getting VaultKeeps from the service', res.data)
        AppState.activeVaultKeeps = res.data
        logger.log('Checking the appstate for VaultKeeps', res.data)
    }
    // async getPrivateVaultKeeps(id){
    //     const res = await api.get(`api/vaults/${id}/keeps`)
    //     AppState.activeVaultKeeps = res.data
    //     logger.log(res.data)
    // }
}

export const vaultKeepsService = new VaultKeepsService()