const API = axios.create({
  baseURL: 'http://localhost:5025/api',
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json',
    Accept: 'application/json'
  }
})

class EmployeesAPI {
  #path = '/employees'
  async get () {
    return await API.get(this.#path)
  }

  async getByNik (nik) {
    return await API.get(this.#path + `/${nik}`)
  }

  async getMaster () {
    return await API.get(this.#path + '/master')
  }

  async post (employee) {
    return await API.post(this.#path, employee)
  }

  async put (employee) {
    const data = {
      ...employee
    }
    delete data.nik
    return await API.put(this.#path + `/${employee.nik}`, data)
  }

  async delete (nik) {
    return await API.delete(this.#path + `/${nik}`)
  }
}

const employeesApi = new EmployeesAPI()

function deleteEmployeeByNik (nik) {
  const confirmationModal = bootstrap.Modal.getOrCreateInstance($('#modal__confirmation'))

  confirmationModal.show()

  $('#modal__confirmation button#yes').on('click', function (e) {
    const loadingModal = bootstrap.Modal.getOrCreateInstance($('#loading'))

    loadingModal.show()

    employeesApi.delete(nik).then(() => {
      setTimeout(() => {
        Swal.fire({
          icon: 'success',
          title: 'Success'
        })
      }, 500)
      populateTableEmployees()
    })
      .catch((err) => {
        const errMsgs = []
        for (const errorsKey in err.response.data.errors) {
          errMsgs.push(...err.response.data.errors[errorsKey])
        }
        setTimeout(() => {
          Swal.fire({
            icon: 'error',
            title: 'Error',
            text: errMsgs.join(' ')
          })
        }, 500)
      })
      .finally(() => {
        setTimeout(() => {
          loadingModal.hide()
        }, 500)
      })
  })
}

function detailsEmployeeByNik (nik) {
  employeesApi.getByNik(nik).then((res) => {
    employeesApi.getByNik(nik).then((res) => {
      $('#modal__detailsEmployee input[name="nik"]').val(res.data.nik)
      $('#modal__detailsEmployee input[name="firstName"]').val(res.data.firstName)
      $('#modal__detailsEmployee input[name="lastName"]').val(res.data.lastName)
      $('#modal__detailsEmployee input[name="birthdate"]').val(res.data.birthdate)
      $('#modal__detailsEmployee input[name="gender"]').val(res.data.gender)
      $('#modal__detailsEmployee input[name="email"]').val(res.data.email)
      $('#modal__detailsEmployee input[name="phoneNumber"]').val(res.data.phoneNumber)

      const modal = bootstrap.Modal.getOrCreateInstance($('#modal__detailsEmployee'))

      modal.show()
    })
  })
}

function populateTableEmployees () {
  employeesApi.getMaster()
    .then((res) => {
      $('table#table__employees tbody').html(
        res.data.map((employee) =>
          $(`
            <tr>
                <th scope="col">${employee.nik}</th>
                <td>${employee.firstName} ${employee.lastName}</td>
                <td>${new Date(employee.birthdate).toLocaleDateString()}</td>
                <td>${employee.gender}</td>
                <td>${employee.email}</td>
                <td class="d-flex justify-content-center align-items-center gap-2">
                    <a id="action__delete" href="#" onclick="deleteEmployeeByNik('${employee.nik}')"><i class="bi bi-trash3-fill"></i></a>
                    <a id="action__details" href="#" onclick="detailsEmployeeByNik('${employee.nik}')"><i class="bi bi-three-dots"></i></a>
                </td>
            </tr>
        `)
        )
      )
    })
    .catch((err) => {
      console.log(err)
    })
}

$('#modal__base').on('hidden.bs.modal', () => {
  $('#modal__base .modal-content').html('')
})

$('#btn__insertEmployee').on('click', () => {
  const modal = bootstrap.Modal.getOrCreateInstance($('#modal__insertEmployee'))

  modal.show()
})

$('#modal__insertEmployee form').on('submit', function (e) {
  const form = $('#modal__insertEmployee form').parsley()

  if (!form.isValid()) return

  e.preventDefault()

  const loadingModal = bootstrap.Modal.getOrCreateInstance($('#loading'))

  loadingModal.show()

  const formData = new FormData(e.target)

  const data = Object.fromEntries(formData.entries())

  employeesApi.post(data)
    .then(() => {
      setTimeout(() => {
        Swal.fire({
          icon: 'success',
          title: 'Success'
        })
      }, 500)
      e.target.reset()
      populateTableEmployees()
    })
    .catch((err) => {
      const errMsgs = []
      for (const errorsKey in err.response.data.errors) {
        errMsgs.push(...err.response.data.errors[errorsKey])
      }
      console.log(errMsgs)
      setTimeout(() => {
        Swal.fire({
          icon: 'error',
          title: 'Error',
          text: errMsgs.join(' ')
        })
      }, 500)
    })
    .finally(() => {
      setTimeout(() => {
        loadingModal.hide()
      }, 500)
    })

  return false
})

$('#modal__detailsEmployee form').on('submit', function (e) {
  const form = $('#modal__detailsEmployee form').parsley()

  if (!form.isValid()) return false

  e.preventDefault()

  const loadingModal = bootstrap.Modal.getOrCreateInstance($('#loading'))

  loadingModal.show()

  const formData = new FormData(e.target)

  const data = Object.fromEntries(formData.entries())

  employeesApi.put(data)
    .then((res) => {
      console.log(res)
      setTimeout(() => {
        Swal.fire({
          icon: 'success',
          title: 'Success'
        })
      }, 500)
      e.target.reset()
      populateTableEmployees()
    })
    .catch((err) => {
      const errMsgs = []
      for (const errorsKey in err.response.data.errors) {
        errMsgs.push(...err.response.data.errors[errorsKey])
      }
      console.log(errMsgs)
      setTimeout(() => {
        Swal.fire({
          icon: 'error',
          title: 'Error',
          text: errMsgs.join(' ')
        })
      }, 500)
    })
    .finally(() => {
      setTimeout(() => {
        loadingModal.hide()
      }, 500)
      const modal = bootstrap.Modal.getOrCreateInstance($('#modal__detailsEmployee'))

      modal.hide()
    })

  return false
})

populateTableEmployees()
