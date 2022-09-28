import { AppState } from "../AppState"
import { logger } from "../utils/Logger"

import { api } from "./AxiosService"

class ProfilesService{
    async getProfileById(id) {
        const res = await api.get(`api/profiles/${id}`)
        AppState.activeProfile = res.data
    }

    async getVaultsByProfileId(id) {
        const res = await api.get(`api/profiles/${id}/vaults`)
        AppState.activeProfileVaults = res.data
        logger.log(res.data)
    }

    async getKeepsByProfileId(id) {
        const res = await api.get(`api/profiles/${id}/keeps`)
        AppState.activeProfileKeeps = res.data
        logger.log(res.data)
    }
}


export const profilesService = new ProfilesService()