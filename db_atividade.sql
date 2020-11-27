-- Table: dbo.atividade

-- DROP TABLE dbo.atividade;

CREATE TABLE dbo.atividade
(
    id integer NOT NULL DEFAULT nextval('dbo.atividade_id_seq'::regclass),
    tarefa text COLLATE pg_catalog."default",
    descricao text COLLATE pg_catalog."default",
    data timestamp without time zone,
    prioridade text COLLATE pg_catalog."default",
    status boolean NOT NULL DEFAULT false,
    CONSTRAINT "PK_dbo.atividade" PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE dbo.atividade
    OWNER to postgres;
	

INSERT INTO public.atividade(id, tarefa, descricao, data, prioridade, status)VALUES (1, 'Fazer Almoço', 'Fazer almoço das crianças', CURRENT_DATE, 'Alta', false);
INSERT INTO public.atividade(id, tarefa, descricao, data, prioridade, status)VALUES (2, 'Reunião', 'Reunião com os moradores da vila', CURRENT_DATE, 'Media', false);
INSERT INTO public.atividade(id, tarefa, descricao, data, prioridade, status)VALUES (3, 'Entrega de Presentes', 'Entregar presentes na comunidade', CURRENT_DATE, 'Media', false);
INSERT INTO public.atividade(id, tarefa, descricao, data, prioridade, status)VALUES (4, 'Estudar', 'Prova de matematica sexta-feira', CURRENT_DATE, 'Alta', false);
INSERT INTO public.atividade(id, tarefa, descricao, data, prioridade, status)VALUES (5, 'Projeto', 'Passar projeto de desenvolvimento para o cliente', CURRENT_DATE, 'Baixa', true);
