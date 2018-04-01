export const currencyMask = (value) => {
    let returnValue = value.toString().replace(/\D/g, '')
    
      if (!returnValue) {
        return ''
      }
    
      returnValue = parseInt(returnValue).toString()
    
      if (returnValue.length === 1) {
        returnValue = `00${returnValue}`
      }
      else if (returnValue.length === 2) {
        returnValue = `0${returnValue}`
      }
    
      returnValue = returnValue.replace(/(\d{1,2})$/, ',$1')
      returnValue = returnValue.replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.')
    
      return returnValue !== '' ? `R$ ${returnValue}` : ''
}
  
export const formatNumberFromCommaToDot = value => value.toString().replace(/[^.,\d]/g, '').split('.').join('').replace(',', '.')