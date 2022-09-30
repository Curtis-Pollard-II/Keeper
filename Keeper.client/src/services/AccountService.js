import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
      Pop.toast(err.message, 'error')
    }
  }
  async getAccountVaults(){
    try {
      const res = await api.get('/account/vaults')
      AppState.activeProfileVaults = res.data
    } catch (err){
      logger.log(err, 'getting account vaults from the service')
      Pop.toast(err.message, 'error')
    }
  }


}

export const accountService = new AccountService()
