printf "..... Executa Angular ......."

ANGULAR_PATH="tarefas-app-angular"

if [ -d "$ANGULAR_PATH" ]; then
    pwd 
    cd "$ANGULAR_PATH"
    if [ ! -d node_modules ]; then
        npm i
    else 
        printf "node_modules já existe!"
    fi
    npm start
fi
