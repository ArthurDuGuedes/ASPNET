async function Get() {
    try {
        const url = "http://localhost:5000/Usuarios";
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
                        <button onclick="Delete(${usuario.id})">Excluir</button>
                        <button onclick="Delete(${usuario.id})">Editar</button>
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

async function POST(evento) {
    
    evento.preventDefault();
    const url = "http://localhost:5000/Usuarios";
    const response = await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            nome:  document.getElementById("nome").value,
            password: document.getElementById("password").value,
            ramal: parseInt(document.getElementById("ramal").value),
            especialidade: document.getElementById("especialidade").value
        })
    }); 
    console.log(response);

}

document.addEventListener("DOMContentLoaded", Get);