class CustoModal{
    constructor(){
        this.modal = document.createElement('div');
        this.modal.className = 'modal-overlay';
        this.modal.innerHTML = `
        <div class="modal-content">
            <div class="modal-header">
                <h3 class="modal-title">Pessoas responsaveis</h3>
                <button class="modal-close">&times;</button>
            </div>
            <div class="modal-body" >
                
            </div>
            <div class="modal-footer" >

            </div>
        </div>
        `
        document.body.appendChild(this.modal)

        this.modal.querySelector('.modal-close').addEventListener('click', () => this.hide())
    }
    show(title, body, buttons = []){
        this.modal.querySelector('.modal-title').innerHTML = title;
        this.modal.querySelector('.modal-body').innerHTML = body;

        const footer = this.modal.querySelector('.modal-footer');
        footer.innerHTML = '';

        buttons.forEach(button => {
            const btn = document.createElement('button')
            btn.className = `btn btn-${button.type || 'secondary'}`
            btn.textContent = button.text;
            btn.addEventListener('click', () => {
                if(button.handler)button.handler();
                if(button.close !== false)this.hide();                       
            })
            footer.appendChild(btn);
        });
        this.modal.classList.add('active');
        document.body.style.overflow = 'hidden'; 
    }

    hide(){
        this.modal.classList.remove('active');
        document.body.style.overflow = '';
    }
}