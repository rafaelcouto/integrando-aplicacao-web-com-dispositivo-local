const app = new Vue({
    el: '#app',
    data: {
        status: null,
        loading: false,
        result: null,
        error: false
    },
    methods: {
        consultarSat: async function() {
            
            this.loading = true;
            

            try {
                let response = await axios.get('http://127.0.0.1:9696/sat/consultar/emulator');
                this.status = 'Conectado';
                this.error = false;
                this.result = response.data;
            } catch (e) {

                this.status = 'Erro';
                this.error = true;

                if (!e.response) {
                    this.result = 'Não foi possível se conectar ao dispositivo';
                    return;
                }

                if (e.response.status === 400) {
                    this.result = e.response.data.message;
                    return;
                }

                this.result = 'Erro desconhecido';

            } finally {
                this.loading = false;
            }

        }
    },
    mounted() {
        this.consultarSat();
    }
});