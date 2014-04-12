typedef struct lval {
    int type;

    long num;


    char* err;
    char* sym;

    int count;

    struct lval** cell;

} lval;

void lval_del(lval*);
lval* builtin_op(lval*, char*);
lval* lval_take(lval*, int);
lval* lval_pop(lval*, int);
lval* lval_eval(lval*);
lval* lval_eval_sexpr(lval*);
void lval_expr_print(lval*, char, char);
int count_ast_leaves(mpc_ast_t*);
int count_ast_branches(mpc_ast_t*);
long l_pow(long, long);
lval* lval_num(long);
lval* lval_err(char*);
void lval_print(lval*);
void lval_println(lval*);

enum lval_type { LVAL_ERR, LVAL_NUM, LVAL_SYM, LVAL_SEXPR };

enum lerr_type { LERR_DIV_ZERO, LERR_BAD_OP, LERR_BAD_NUM };