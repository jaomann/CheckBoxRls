async function registerUser() {
    const data = {
        name: $('#userName').val(),
        surname: $('#userSurname').val(),
        email: $('#userEmail').val(),
        password: $('#userPassword').val()
    }
    try {
        const response = await fetch('/api/auth/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        if (response.ok) {
            Swal.fire({
                title: 'Success!',
                text: 'Usuário cadastrado com sucesso',
                icon: 'success',
                confirmButtonText: 'Valeu!'
            });
        }
        else if (response.status != 200) {
            var text = await response.text();
            Swal.fire({
                title: 'Problema no cadastro',
                text: `${text}`,
                icon: 'error',
                confirmButtonText: 'Ok!'
            });
        }
    }catch (error) {
        Swal.fire({
            title: 'Problema no cadastro',
            text: 'Verifique seus dados',
            icon: 'error',
            confirmButtonText: 'Ok'
        });
    }
}
async function login() {
    const data = {
        email: $('.userEmailLogin').val(),
        password: $('.userPasswordLogin').val()
    }
    try {
        const response = await fetch('/api/auth/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        if (response.ok)
            location.href = '/note/index';
        else
            Swal.fire({
                title: 'Login incorreto',
                text: 'Verifique seus dados',
                icon: 'error',
                confirmButtonText: 'OK'
            });
    }catch(error){
        console.log(error)
    }
}
