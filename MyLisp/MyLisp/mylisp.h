typedef struct {
    int type;
    long num;
    int err;
} lval;

lval eval(mpc_ast_t* );
lval eval_op(lval, char*, lval);
int count_ast_leaves(mpc_ast_t*);
int count_ast_branches(mpc_ast_t*);
long l_pow(long, long);
lval lval_num(long x);
lval lval_err(int x);
void lval_print(lval v);
void lval_println(lval v);

enum { LVAL_NUM, LVAL_ERR };

enum { LERR_DIV_ZERO, LERR_BAD_OP, LERR_BAD_NUM };
