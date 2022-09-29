import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class VaultKeepsService {

   async GetVault (id){
        const res = await api.get(`api/vaults/${id}`)
        logger.log('active vault from the service', res.data)
        AppState.activeVault = res.data
   }
    async getVaultKeeps(id){
        const res = await api.get(`api/vaults/${id}/keeps`)
        logger.log('getting VaultKeeps from the service', res.data)
        AppState.activeVaultKeeps = res.data
        logger.log('Checking the appstate for VaultKeeps', res.data)
    }

    async deleteVault(id){
        const res = await api.delete(`api/vaults/${id}`)
        AppState.activeProfileVaults = AppState.activeProfileVaults.filter(v => v.id != id)
    }

    setActiveVault(vault){
        AppState.activeVault = vault
    }

    async createVault(vaultData){
        let res = await api.post(`api/vaults`, vaultData)
        logger.log('creating vualt from the service', res.data)
        AppState.activeProfileVaults.push(res.data)

    }
}

export const vaultKeepsService = new VaultKeepsService()