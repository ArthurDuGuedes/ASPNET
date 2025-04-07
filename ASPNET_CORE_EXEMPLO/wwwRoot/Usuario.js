const url = "http://localhost:5000/Usuarios";

async function Get() {
    try {
        const response = await fetch(url);
        if (response.ok) {
            const usuarios = await response.json();
            console.log(usuarios);

            const tbody = document.querySelector("table tbody");
            tbody.innerHTML = "";

            usuarios.forEach((usuario) => {
                const row = `
                <tr>
                    <td>${usuario.nome}</td>
                    <td>${usuario.password}</td>
                    <td>${usuario.ramal}</td>
                    <td>${usuario.especialidade}</td>
                    <td>
                        <button class="btn btn-primary" onclick="Editar(${usuario.id})">Editar</button>
                        <button class="btn btn-danger" onclick="Delete(${usuario.id})">Excluir</button>
                    </td>
                </tr>
                `;
                tbody.innerHTML += row;
            });
        }
    } catch (error) {
        console.log("Erro ao buscar usuários:", error);
    }
}

async function Salvar(evento) {
    evento.preventDefault();

    const id = document.getElementById("id").value;
    const nome = document.getElementById("nome").value;
    const password = document.getElementById("password").value;
    const ramal = parseInt(document.getElementById("ramal").value);
    const especialidade = document.getElementById("especialidade").value;

    const metodo = id ? "PUT" : "POST";
    const endpoint = id ? `${url}/${id}` : url;

    const response = await fetch(endpoint, {
        method: metodo,
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ nome, password, ramal, especialidade })
    });

    if (response.ok) {
        alert(id ? "Usuário atualizado!" : "Usuário cadastrado!");
        document.getElementById("userForm").reset();
        document.getElementById("id").value = "";
        document.getElementById("botao").innerText = "Cadastrar";
        Get();
    } else {
        alert("Erro ao salvar usuário.");
    }
}


async function Delete(id) {
    if (confirm("Tem certeza que deseja excluir este usuário?")) {
        const response = await fetch(`${url}/${id}`, { method: "DELETE" });
        if (response.ok) {
            alert("Usuário excluído!");
            Get();
        } else {
            alert("Erro ao excluir usuário.");
        }
    }
}


async function Editar(id) {
    try {
        const response = await fetch("http://localhost:5000/Usuarios")
        if (response.ok) {
            const usuarios = await response.json();

            
            const usuario = usuarios.find(user => user.id == id);
            if (!usuario) {
                alert("Usuário não encontrado!");
                return;
            }        
            document.getElementById("id").value = usuario.id;
            document.getElementById("nome").value = usuario.nome;
            document.getElementById("password").value = usuario.password;
            document.getElementById("ramal").value = usuario.ramal;
            document.getElementById("especialidade").value = usuario.especialidade;

            document.getElementById("botao").innerText = "Atualizar";
        }
    } catch (error) {
        console.log("Erro ao buscar usuário para edição:", error);
    }
}

document.addEventListener("DOMContentLoaded", Get);
