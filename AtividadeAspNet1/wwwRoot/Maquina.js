const url = "http://localhost:5000/Maquinas";
async function Get() {
    try {
        const response = await fetch(url);
        if (response.ok) {
            const Maquinas = await response.json();
            console.log(Maquinas);

            const tbody = document.querySelector("table tbody");
            tbody.innerHTML = "";

            Maquinas.forEach((Maquina) => {
                const row = `
                <tr>
                    <td>${Maquina.tipo}</td>
                    <td>${Maquina.velocidade}</td>
                    <td>${Maquina.hardDisk}</td>
                    <td>${Maquina.placaRede}</td>
                    <td>${Maquina.memoriaRam}</td>
                    <td>${Maquina.fk_usuario}</td>
                    <td>
                        <button class="btn btn-primary" onclick="Editar(${Maquina.id})">Editar</button>
                        <button class="btn btn-danger" onclick="Delete(${Maquina.id})">Excluir</button>
                    </td>
                </tr>
                `;
                tbody.innerHTML += row;
            });
        }
    } catch (error) {
        console.log("Erro ao buscar máquinas:", error);
    }
}

async function Salvar(evento) {
    evento.preventDefault();

    const id = document.getElementById("id").value;
    const tipo = document.getElementById("tipo").value;
    const velocidade = parseInt(document.getElementById("velocidade").value);
    const hardDisk = parseInt(document.getElementById("hardDisk").value);
    const placaRede = parseInt(document.getElementById("placaRede").value);
    const memoriaRam = parseInt(document.getElementById("memoriaRam").value);
    const fk_usuario = parseInt(document.getElementById("fk_usuario").value);

    const metodo = id ? "PUT" : "POST";
    const endpoint = id ? `${url}/${id}` : url;

    const response = await fetch(endpoint, {
        method: metodo,
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ tipo, velocidade, hardDisk, placaRede, memoriaRam, fk_usuario })
    });

    if (response.ok) {
        alert(id ? "Máquina atualizada!" : "Máquina cadastrada!");
        document.getElementById("userForm").reset();
        document.getElementById("id").value = "";
        document.getElementById("botao").innerText = "Cadastrar";
        Get();
    } else {
        alert("Erro ao salvar máquina.");
    }
}

async function Delete(id) {
    if (confirm("Tem certeza que deseja excluir esta máquina?")) {
        const response = await fetch(`${url}/${id}`, { method: "DELETE" });
        if (response.ok) {
            alert("Máquina excluída!");
            Get();
        } else {
            alert("Erro ao excluir máquina.");
        }
    }
}

async function Editar(id) {
    try {
        const response = await fetch(`${url}/${id}`);
        if (response.ok) {
            const Maquina = await response.json();

            document.getElementById("id").value = Maquina.id;
            document.getElementById("tipo").value = Maquina.tipo;
            document.getElementById("velocidade").value = Maquina.velocidade;
            document.getElementById("hardDisk").value = Maquina.hardDisk;
            document.getElementById("placaRede").value = Maquina.placaRede;
            document.getElementById("memoriaRam").value = Maquina.memoriaRam;
            document.getElementById("fk_usuario").value = Maquina.fk_usuario;

            document.getElementById("botao").innerText = "Atualizar";
        }
    } catch (error) {
        console.log("Erro ao buscar máquina para edição:", error);
    }
}

document.addEventListener("DOMContentLoaded", Get);
