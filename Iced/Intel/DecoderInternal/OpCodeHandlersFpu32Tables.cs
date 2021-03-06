/*
Copyright (C) 2018-2019 de4dot@gmail.com

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

#if !NO_DECODER32 && !NO_DECODER
namespace Iced.Intel.DecoderInternal.OpCodeHandlers32 {
	/// <summary>
	/// x87 opcode handlers
	/// </summary>
	static class OpCodeHandlersFpu32Tables {
		public static readonly OpCodeHandler[] handlers_FPU_D8_low;
		public static readonly OpCodeHandler[] handlers_FPU_D8_high;
		public static readonly OpCodeHandler[] handlers_FPU_D9_low;
		public static readonly OpCodeHandler[] handlers_FPU_D9_high;
		public static readonly OpCodeHandler[] handlers_FPU_DA_low;
		public static readonly OpCodeHandler[] handlers_FPU_DA_high;
		public static readonly OpCodeHandler[] handlers_FPU_DB_low;
		public static readonly OpCodeHandler[] handlers_FPU_DB_high;
		public static readonly OpCodeHandler[] handlers_FPU_DC_low;
		public static readonly OpCodeHandler[] handlers_FPU_DC_high;
		public static readonly OpCodeHandler[] handlers_FPU_DD_low;
		public static readonly OpCodeHandler[] handlers_FPU_DD_high;
		public static readonly OpCodeHandler[] handlers_FPU_DE_low;
		public static readonly OpCodeHandler[] handlers_FPU_DE_high;
		public static readonly OpCodeHandler[] handlers_FPU_DF_low;
		public static readonly OpCodeHandler[] handlers_FPU_DF_high;

		static OpCodeHandlersFpu32Tables() {
			var invalid = OpCodeHandler_Invalid.Instance;

			handlers_FPU_D8_low = new OpCodeHandler[8] {
				new OpCodeHandler_Mf32(Code.Fadd_m32fp),
				new OpCodeHandler_Mf32(Code.Fmul_m32fp),
				new OpCodeHandler_Mf32(Code.Fcom_m32fp),
				new OpCodeHandler_Mf32(Code.Fcomp_m32fp),
				new OpCodeHandler_Mf32(Code.Fsub_m32fp),
				new OpCodeHandler_Mf32(Code.Fsubr_m32fp),
				new OpCodeHandler_Mf32(Code.Fdiv_m32fp),
				new OpCodeHandler_Mf32(Code.Fdivr_m32fp),
			};

			handlers_FPU_D8_high = new OpCodeHandler[8] {
				new OpCodeHandler_ST_STi(Code.Fadd_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fmul_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcom_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomp_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fsub_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fsubr_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fdiv_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fdivr_st0_sti),
			};

			handlers_FPU_D9_low = new OpCodeHandler[8] {
				new OpCodeHandler_Mf32(Code.Fld_m32fp),
				invalid,
				new OpCodeHandler_Mf32(Code.Fst_m32fp),
				new OpCodeHandler_Mf32(Code.Fstp_m32fp),
				new OpCodeHandler_Mf(Code.Fldenv_m14byte, Code.Fldenv_m28byte),
				new OpCodeHandler_Mf2(Code.Fldcw_m16),
				new OpCodeHandler_Mf(Code.Fnstenv_m14byte, Code.Fnstenv_m28byte),
				new OpCodeHandler_Mf2(Code.Fnstcw_m16),
			};

			handlers_FPU_D9_high = new OpCodeHandler[0x40] {
				// C0
				new OpCodeHandler_ST_STi(Code.Fld_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fld_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fld_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fld_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fld_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fld_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fld_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fld_st0_sti),

				// C8
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti),

				// D0
				new OpCodeHandler_Simple(Code.Fnop),
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,

				// D8
				new OpCodeHandler_STi(Code.Fstpnce_sti),
				new OpCodeHandler_STi(Code.Fstpnce_sti),
				new OpCodeHandler_STi(Code.Fstpnce_sti),
				new OpCodeHandler_STi(Code.Fstpnce_sti),
				new OpCodeHandler_STi(Code.Fstpnce_sti),
				new OpCodeHandler_STi(Code.Fstpnce_sti),
				new OpCodeHandler_STi(Code.Fstpnce_sti),
				new OpCodeHandler_STi(Code.Fstpnce_sti),

				// E0
				new OpCodeHandler_Simple(Code.Fchs),
				new OpCodeHandler_Simple(Code.Fabs),
				invalid,
				invalid,
				new OpCodeHandler_Simple(Code.Ftst),
				new OpCodeHandler_Simple(Code.Fxam),
				invalid,
				invalid,

				// E8
				new OpCodeHandler_Simple(Code.Fld1),
				new OpCodeHandler_Simple(Code.Fldl2t),
				new OpCodeHandler_Simple(Code.Fldl2e),
				new OpCodeHandler_Simple(Code.Fldpi),
				new OpCodeHandler_Simple(Code.Fldlg2),
				new OpCodeHandler_Simple(Code.Fldln2),
				new OpCodeHandler_Simple(Code.Fldz),
				invalid,

				// F0
				new OpCodeHandler_Simple(Code.F2xm1),
				new OpCodeHandler_Simple(Code.Fyl2x),
				new OpCodeHandler_Simple(Code.Fptan),
				new OpCodeHandler_Simple(Code.Fpatan),
				new OpCodeHandler_Simple(Code.Fxtract),
				new OpCodeHandler_Simple(Code.Fprem1),
				new OpCodeHandler_Simple(Code.Fdecstp),
				new OpCodeHandler_Simple(Code.Fincstp),

				// F8
				new OpCodeHandler_Simple(Code.Fprem),
				new OpCodeHandler_Simple(Code.Fyl2xp1),
				new OpCodeHandler_Simple(Code.Fsqrt),
				new OpCodeHandler_Simple(Code.Fsincos),
				new OpCodeHandler_Simple(Code.Frndint),
				new OpCodeHandler_Simple(Code.Fscale),
				new OpCodeHandler_Simple(Code.Fsin),
				new OpCodeHandler_Simple(Code.Fcos),
			};

			handlers_FPU_DA_low = new OpCodeHandler[8] {
				new OpCodeHandler_Mfi32(Code.Fiadd_m32int),
				new OpCodeHandler_Mfi32(Code.Fimul_m32int),
				new OpCodeHandler_Mfi32(Code.Ficom_m32int),
				new OpCodeHandler_Mfi32(Code.Ficomp_m32int),
				new OpCodeHandler_Mfi32(Code.Fisub_m32int),
				new OpCodeHandler_Mfi32(Code.Fisubr_m32int),
				new OpCodeHandler_Mfi32(Code.Fidiv_m32int),
				new OpCodeHandler_Mfi32(Code.Fidivr_m32int),
			};

			handlers_FPU_DA_high = new OpCodeHandler[0x40] {
				// C0
				new OpCodeHandler_ST_STi(Code.Fcmovb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovb_st0_sti),

				// C8
				new OpCodeHandler_ST_STi(Code.Fcmove_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmove_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmove_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmove_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmove_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmove_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmove_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmove_st0_sti),

				// D0
				new OpCodeHandler_ST_STi(Code.Fcmovbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovbe_st0_sti),

				// D8
				new OpCodeHandler_ST_STi(Code.Fcmovu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovu_st0_sti),

				// E0
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,

				// E8
				invalid,
				new OpCodeHandler_Simple(Code.Fucompp),
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,

				// F0
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,

				// F8
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
			};

			handlers_FPU_DB_low = new OpCodeHandler[8] {
				new OpCodeHandler_Mfi32(Code.Fild_m32int),
				new OpCodeHandler_Mfi32(Code.Fisttp_m32int),
				new OpCodeHandler_Mfi32(Code.Fist_m32int),
				new OpCodeHandler_Mfi32(Code.Fistp_m32int),
				invalid,
				new OpCodeHandler_Mf80(Code.Fld_m80fp),
				invalid,
				new OpCodeHandler_Mf80(Code.Fstp_m80fp),
			};

			handlers_FPU_DB_high = new OpCodeHandler[0x40] {
				// C0
				new OpCodeHandler_ST_STi(Code.Fcmovnb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnb_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnb_st0_sti),

				// C8
				new OpCodeHandler_ST_STi(Code.Fcmovne_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovne_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovne_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovne_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovne_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovne_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovne_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovne_st0_sti),

				// D0
				new OpCodeHandler_ST_STi(Code.Fcmovnbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnbe_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnbe_st0_sti),

				// D8
				new OpCodeHandler_ST_STi(Code.Fcmovnu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnu_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcmovnu_st0_sti),

				// E0
				new OpCodeHandler_Simple(Code.Fneni),
				new OpCodeHandler_Simple(Code.Fndisi),
				new OpCodeHandler_Simple(Code.Fnclex),
				new OpCodeHandler_Simple(Code.Fninit),
				new OpCodeHandler_Simple(Code.Fnsetpm),
				new OpCodeHandler_Options(
					invalid,
					new OpCodeHandler_Simple(Code.Frstpm), DecoderOptions.OldFpu
				),
				invalid,
				invalid,

				// E8
				new OpCodeHandler_ST_STi(Code.Fucomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomi_st0_sti),

				// F0
				new OpCodeHandler_ST_STi(Code.Fcomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomi_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomi_st0_sti),

				// F8
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
			};

			handlers_FPU_DC_low = new OpCodeHandler[8] {
				new OpCodeHandler_Mf64(Code.Fadd_m64fp),
				new OpCodeHandler_Mf64(Code.Fmul_m64fp),
				new OpCodeHandler_Mf64(Code.Fcom_m64fp),
				new OpCodeHandler_Mf64(Code.Fcomp_m64fp),
				new OpCodeHandler_Mf64(Code.Fsub_m64fp),
				new OpCodeHandler_Mf64(Code.Fsubr_m64fp),
				new OpCodeHandler_Mf64(Code.Fdiv_m64fp),
				new OpCodeHandler_Mf64(Code.Fdivr_m64fp),
			};

			handlers_FPU_DC_high = new OpCodeHandler[8] {
				new OpCodeHandler_STi_ST(Code.Fadd_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fmul_sti_st0),
				new OpCodeHandler_ST_STi(Code.Fcom_st0_sti_DCD0),
				new OpCodeHandler_ST_STi(Code.Fcomp_st0_sti_DCD8),
				new OpCodeHandler_STi_ST(Code.Fsubr_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsub_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivr_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdiv_sti_st0),
			};

			handlers_FPU_DD_low = new OpCodeHandler[8] {
				new OpCodeHandler_Mf64(Code.Fld_m64fp),
				new OpCodeHandler_Mf64(Code.Fisttp_m64fp),
				new OpCodeHandler_Mf64(Code.Fst_m64fp),
				new OpCodeHandler_Mf64(Code.Fstp_m64fp),
				new OpCodeHandler_Mf(Code.Frstor_m94byte, Code.Frstor_m108byte),
				invalid,
				new OpCodeHandler_Mf(Code.Fnsave_m94byte, Code.Fnsave_m108byte),
				new OpCodeHandler_Mf2(Code.Fnstsw_m16),
			};

			handlers_FPU_DD_high = new OpCodeHandler[8] {
				new OpCodeHandler_STi(Code.Ffree_sti),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti_DDC8),
				new OpCodeHandler_STi(Code.Fst_sti),
				new OpCodeHandler_STi(Code.Fstp_sti),
				new OpCodeHandler_ST_STi(Code.Fucom_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomp_st0_sti),
				invalid,
				invalid,
			};

			handlers_FPU_DE_low = new OpCodeHandler[8] {
				new OpCodeHandler_Mfi16(Code.Fiadd_m16int),
				new OpCodeHandler_Mfi16(Code.Fimul_m16int),
				new OpCodeHandler_Mfi16(Code.Ficom_m16int),
				new OpCodeHandler_Mfi16(Code.Ficomp_m16int),
				new OpCodeHandler_Mfi16(Code.Fisub_m16int),
				new OpCodeHandler_Mfi16(Code.Fisubr_m16int),
				new OpCodeHandler_Mfi16(Code.Fidiv_m16int),
				new OpCodeHandler_Mfi16(Code.Fidivr_m16int),
			};

			handlers_FPU_DE_high = new OpCodeHandler[0x40] {
				// C0
				new OpCodeHandler_STi_ST(Code.Faddp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Faddp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Faddp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Faddp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Faddp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Faddp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Faddp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Faddp_sti_st0),

				// C8
				new OpCodeHandler_STi_ST(Code.Fmulp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fmulp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fmulp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fmulp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fmulp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fmulp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fmulp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fmulp_sti_st0),

				// D0
				new OpCodeHandler_ST_STi(Code.Fcomp_st0_sti_DED0),
				new OpCodeHandler_ST_STi(Code.Fcomp_st0_sti_DED0),
				new OpCodeHandler_ST_STi(Code.Fcomp_st0_sti_DED0),
				new OpCodeHandler_ST_STi(Code.Fcomp_st0_sti_DED0),
				new OpCodeHandler_ST_STi(Code.Fcomp_st0_sti_DED0),
				new OpCodeHandler_ST_STi(Code.Fcomp_st0_sti_DED0),
				new OpCodeHandler_ST_STi(Code.Fcomp_st0_sti_DED0),
				new OpCodeHandler_ST_STi(Code.Fcomp_st0_sti_DED0),

				// D8
				invalid,
				new OpCodeHandler_Simple(Code.Fcompp),
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,

				// E0
				new OpCodeHandler_STi_ST(Code.Fsubrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubrp_sti_st0),

				// E8
				new OpCodeHandler_STi_ST(Code.Fsubp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fsubp_sti_st0),

				// F0
				new OpCodeHandler_STi_ST(Code.Fdivrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivrp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivrp_sti_st0),

				// F8
				new OpCodeHandler_STi_ST(Code.Fdivp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivp_sti_st0),
				new OpCodeHandler_STi_ST(Code.Fdivp_sti_st0),
			};

			handlers_FPU_DF_low = new OpCodeHandler[8] {
				new OpCodeHandler_Mfi16(Code.Fild_m16int),
				new OpCodeHandler_Mfi16(Code.Fisttp_m16int),
				new OpCodeHandler_Mfi16(Code.Fist_m16int),
				new OpCodeHandler_Mfi16(Code.Fistp_m16int),
				new OpCodeHandler_Mfbcd(Code.Fbld_m80bcd),
				new OpCodeHandler_Mfi64(Code.Fild_m64int),
				new OpCodeHandler_Mfbcd(Code.Fbstp_m80bcd),
				new OpCodeHandler_Mfi64(Code.Fistp_m64int),
			};

			handlers_FPU_DF_high = new OpCodeHandler[0x40] {
				// C0
				new OpCodeHandler_STi(Code.Ffreep_sti),
				new OpCodeHandler_STi(Code.Ffreep_sti),
				new OpCodeHandler_STi(Code.Ffreep_sti),
				new OpCodeHandler_STi(Code.Ffreep_sti),
				new OpCodeHandler_STi(Code.Ffreep_sti),
				new OpCodeHandler_STi(Code.Ffreep_sti),
				new OpCodeHandler_STi(Code.Ffreep_sti),
				new OpCodeHandler_STi(Code.Ffreep_sti),

				// C8
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti_DFC8),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti_DFC8),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti_DFC8),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti_DFC8),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti_DFC8),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti_DFC8),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti_DFC8),
				new OpCodeHandler_ST_STi(Code.Fxch_st0_sti_DFC8),

				// D0
				new OpCodeHandler_STi(Code.Fstp_sti_DFD0),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD0),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD0),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD0),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD0),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD0),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD0),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD0),

				// D8
				new OpCodeHandler_STi(Code.Fstp_sti_DFD8),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD8),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD8),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD8),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD8),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD8),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD8),
				new OpCodeHandler_STi(Code.Fstp_sti_DFD8),

				// E0
				new OpCodeHandler_Reg(Code.Fnstsw_AX, Register.AX),
				new OpCodeHandler_Options(
					invalid,
					new OpCodeHandler_Reg(Code.Fstdw_AX, Register.AX), DecoderOptions.OldFpu
				),
				new OpCodeHandler_Options(
					invalid,
					new OpCodeHandler_Reg(Code.Fstsg_AX, Register.AX), DecoderOptions.OldFpu
				),
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,

				// E8
				new OpCodeHandler_ST_STi(Code.Fucomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fucomip_st0_sti),

				// F0
				new OpCodeHandler_ST_STi(Code.Fcomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomip_st0_sti),
				new OpCodeHandler_ST_STi(Code.Fcomip_st0_sti),

				// F8
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
				invalid,
			};
		}
	}
}
#endif
