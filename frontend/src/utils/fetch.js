import Axios from 'axios'

function Fetch() {
  const hashKey = 'AUTH-TOKEN-HASH'

  const instance = Axios.create({
    baseURL: 'http://localhost:9977/api/',
    timeout: 100000,
    headers: {
      'Access-Control-Allow-Origin': '*',
    },
  })

  const handleError = (res) => {
    const status = res.status || (res.response ? res.response.status : null)
    if (status === 401) {
      localStorage.clear()
      window.location.href = '/login'
    }
  }

  const getRequestConfig = (config) => {
    const hash = localStorage.getItem(hashKey)
    
    if (hash) {
      config.headers['Content-type'] = 'application/json'
      config.headers['AUTH'] = hash
    }
    return config
  }

  const handleErrorPromise = (error) => {
    handleError(error)
    return Promise.reject(error)
  }

  const getResolvedInterceptor = (response) => {
    handleError(response)
    return response
  }

  instance.interceptors.request.use(getRequestConfig, handleErrorPromise)
  instance.interceptors.response.use(getResolvedInterceptor, handleErrorPromise)

  return {
    get: url => instance.get(url),
    post: (url, data) => instance.post(url, data),
    delete: url => instance.delete(url),
    put: (url, data) => instance.put(url, data),
    hashKey,
  }
}

export default Fetch()
