struct lval;
struct lenv;
typedef struct lval lval;
typedef struct lenv lenv;
typedef enum lval_type lval_type;
typedef enum lerr_type lerr_type;

enum lval_type { LVAL_ERR, LVAL_NUM, LVAL_SYM, LVAL_SEXPR, LVAL_QEXPR, LVAL_FUN };
enum lerr_type { LERR_DIV_ZERO, LERR_BAD_OP, LERR_BAD_NUM };

typedef lval*(*lbuiltin)(lenv*, lval*);

struct lval {
    lval_type type;

    long num;
    char* err;
    char* sym;
    lbuiltin fun;

    int count;
    lval** cell;

};

struct lenv {
	int count;
	char** syms;
	lval** vals;
};

void lval_del(lval*);
lval* builtin_op(lenv*, lval*, char*);
lval* lval_take(lval*, int);
lval* lval_pop(lval*, int);
lval* lval_copy(lval*);
lval* lval_eval(lenv*, lval*);
lval* lval_eval_sexpr(lenv*, lval*);
void lval_expr_print(lval*, char, char);
int count_ast_leaves(mpc_ast_t*);
int count_ast_branches(mpc_ast_t*);
long l_pow(long, long);
lval* lval_num(long);
lval* lval_sym(char*);
lval* lval_fun(lbuiltin);
lval* lval_err(char*, ...);
lval* lval_sexpr(void);
lval* lval_qexpr(void);
void lval_print(lval*);
void lval_println(lval*);

//lval* builtin(lval*, char*);
lval* builtin_head(lenv*, lval*);
lval* builtin_list(lenv*, lval*);
lval* builtin_eval(lenv*, lval*);
lval* builtin_join(lenv*, lval*);
lval* builtin_add(lenv*, lval*);
lval* builtin_tail(lenv*, lval*);
lval* builtin_sub(lenv*, lval*);
lval* builtin_div(lenv*, lval*);
lval* builtin_mul(lenv*, lval*);
lval* builtin_mod(lenv*, lval*);
lval* lval_join(lval*, lval*);
lval* lval_add(lval*, lval*);
lval* builtin_len(lenv*, lval*);
lval* builtin_def(lenv*, lval*);

void lenv_add_builtin(lenv*, char*, lbuiltin);
void lenv_add_builtins(lenv*);
void lenv_put(lenv*, lval*, lval*);
lval* lenv_get(lenv*, lval*);
void lenv_del(lenv*);
lenv* lenv_new(void);

#define LASSERT(args, cond, fmt, ...) \
	if(!(cond)) { \
		lval* err = lval_err(fmt, ##__VA_ARGS__); \
		lval_del(args); \
		return err; \
	}
